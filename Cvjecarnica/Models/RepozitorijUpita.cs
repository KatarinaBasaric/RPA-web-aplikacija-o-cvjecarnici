using Microsoft.EntityFrameworkCore;

namespace Cvjecarnica.Models
{
    public class RepozitorijUpita : IRepozitorijUpita
    {
        private readonly Data.ApplicationDbContext _applicationDbContext;
        public RepozitorijUpita(Data.ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public void Create(Cvijet cvijet)
        {
            _applicationDbContext.Add(cvijet);
            _applicationDbContext.SaveChanges();

        }

        public void Create(Kategorija kategorija)
        {
            _applicationDbContext.Add(kategorija);
            _applicationDbContext.SaveChanges();

        }

        public void Delete(Cvijet cvijet)
        {
            _applicationDbContext.Cvijece.Remove(cvijet);
            _applicationDbContext.SaveChanges();

        }

        public void Delete(Kategorija kategorija)
        {
            _applicationDbContext.Kategorija.Remove(kategorija);
            _applicationDbContext.SaveChanges();

        }

        public Cvijet DohvatiCvijetSIdom(int id)
        {
            return _applicationDbContext.Cvijece.Include(k => k.Kategorija).FirstOrDefault(f => f.Id == id);
        }

        public Kategorija DohvatiKategorijuSIdom(int id)
        {
            return _applicationDbContext.Kategorija.Find(id);
        }
        public int KategorijaSljedeciId()
        {
            int zadnjiId = _applicationDbContext.Kategorija
               .Count();

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public IEnumerable<Cvijet> PopisCvijet()
        {
            return _applicationDbContext.Cvijece.Include(k => k.Kategorija);
        }

        public IEnumerable<Kategorija> PopisKategorija()
        {
            return _applicationDbContext.Kategorija;
        }

        public int SljedeciId()
        {
            int zadnjiId = _applicationDbContext.Cvijece.Include(k => k.Kategorija).Max(x => x.Id);
            int sljedeciId = zadnjiId + 1;
            return sljedeciId;

        }

        public void Update(Cvijet cvijet)
        {
            _applicationDbContext.Cvijece.Update(cvijet);
            _applicationDbContext.SaveChanges();

        }

        public void Update(Kategorija kategorija)
        {
            _applicationDbContext.Kategorija.Update(kategorija);
            _applicationDbContext.SaveChanges();

        }

    }
}
