namespace FinanceManagementMvcUi.ViewModels
{
    using System.Collections.ObjectModel;
    using FinanceManagement.ETL.Models;

    public class AdminViewModel
    {
        public Collection<ImportFileType> Configurations;
        public Collection<ImportFileBatch> Batches;
        public string ViewName { get; set; }

        public AdminViewModel(Collection<ImportFileType> configurations, Collection<ImportFileBatch> batches)
        {
            Configurations = configurations;
            Batches = batches;
            ViewName = "Test";
        }
    }
}
