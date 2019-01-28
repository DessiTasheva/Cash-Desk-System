
namespace CashDeskApi.Models
{
    public class CashDeskDto
    {
        public int Id { get; set; }
        public CashDeskState State { get; set; }
        public int CameraId { get; set; }
        public bool isOpen { get; set; }
    }

}