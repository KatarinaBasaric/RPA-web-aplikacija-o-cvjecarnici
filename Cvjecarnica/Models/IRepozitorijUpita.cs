namespace Cvjecarnica.Models
{
    public interface IRepozitorijUpita
    {
        IEnumerable<Cvijet> PopisCvijet(); 
        void Create(Cvijet cvijet); 
        void Delete(Cvijet cvijet); 
        void Update(Cvijet cvijet); 

        int SljedeciId();

        int KategorijaSljedeciId();

        Cvijet DohvatiCvijetSIdom(int id);

        IEnumerable<Kategorija> PopisKategorija();
        void Create(Kategorija kategorija);
        void Delete(Kategorija kategorija);
        void Update(Kategorija kategorija);

        Kategorija DohvatiKategorijuSIdom(int id);

    }
}
