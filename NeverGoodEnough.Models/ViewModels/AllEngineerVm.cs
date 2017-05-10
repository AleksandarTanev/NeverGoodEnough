
namespace NeverGoodEnough.Models.ViewModels
{
    using System.ComponentModel;

    public class AllEngineerVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Created Games")]
        public int Games { get; set; }

        [DisplayName("Created Components")]
        public int GameComponents { get; set; }
    }
}
