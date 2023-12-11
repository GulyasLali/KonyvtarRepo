
namespace RealKonyvtar.Shared
{
    public class Kolcsonzes
    {
        public int Id { get; set; }
        public required int OlvId { get; set; }

        public required int KonyvId { get; set; }

        public required DateTime BringOut { get; set; }
        public required DateTime BringBack { get; set; }




    }

}
