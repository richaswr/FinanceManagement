namespace FinanceManagementMvcUi.Services
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using FinanceManagement.ETL.Models;
    using FinanceManagement.ETL.Repositories;

    public class EtlService : IEtlService
    {
        private readonly IEtlRepository _etlRepository;

        public EtlService(IEtlRepository etlRepository)
        {
            _etlRepository = etlRepository;
        }

        public Collection<ImportFileType> GetImportFileTypes()
        {
            return _etlRepository.GetImportFileTypes();
        }

        public Collection<ImportFileType> GetActiveImportFileTypes()
        {
            var importFileTypes = new Collection<ImportFileType>();
            foreach (var importFileType in GetImportFileTypes().Where(w => w.IsActive))
            {
                importFileTypes.Add(importFileType);
            }

            return importFileTypes;
        }

        public ImportFileType GetImportFileTypeById(int importFileTypeId)
        {
            return GetImportFileTypes().SingleOrDefault(s => s.ImportFileTypeId == importFileTypeId);
        }

        public void UpdateImportFileType(ImportFileType importFileType)
        {
            _etlRepository.UpdateImportFileType(importFileType);
        }

        public ImportFileType CreateImportFileType(ImportFileType importFileType)
        {
            return _etlRepository.CreateImportFileType(importFileType);
        }
    }
}
