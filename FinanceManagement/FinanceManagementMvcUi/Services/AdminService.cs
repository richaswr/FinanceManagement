namespace FinanceManagementMvcUi.Services
{
    using FinanceManagement.ETL.Repositories;
    using ViewModels;

    public class AdminService : IAdminService
    {
        private readonly EtlService _etlService;

        public AdminService()
        {
            _etlService = new EtlService(new EtlRepository());
        }

        public AdminViewModel GetAdminViewModel()
        {
            var configs = _etlService.GetImportFileTypes();
            var batches = _etlService.GetImportFileBatches();

            return new AdminViewModel(configs, batches);
        }
    }
}
