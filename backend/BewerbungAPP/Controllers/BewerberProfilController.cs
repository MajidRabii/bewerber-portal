using BewerbungAPP.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BewerbungAPP.Models;
using BewerbungAPP.ViewModels;

namespace BewerbungAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BewerberProfilController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BewerberProfilController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BewerberProfilViewModel>>> GetAll()
        {
            var data = await _context.BewerberprofilModel.ToListAsync();
            var result = _mapper.Map<List<BewerberProfilViewModel>>(data);
            return Ok(result);

            /*
            var data = await _context.Profile
                .Include(p => p.Beruf1)
                .Join(_context.Personen,
                      profil => profil.Person_Id,
                      person => person.Id,
                      (profil, person) => new { person, profil })
                .ToListAsync();

            var result = _mapper.Map<List<BewerberProfilViewModel>>(data.Select(x => (x.person, x.profil)));
            */
            /*
            var result = await _context.Personen
                .Join(_context.Profile,
                    person => person.Id,
                    profil => profil.Person_Id,
                    (person, profil) => new BewerberProfilViewModel
                    {
                        PersonId = person.Id,
                        Anrede = person.Anrede,
                        Vorname = person.Vorname,
                        Nachname = person.Nachname,
                        Geburtstag = person.Geburtstag,
                        Geburtsort_Id = person.Geburtsort_Id,
                        Adresse = person.Adresse,
                        Laendercode = person.Laendercode,
                        Handynummer = person.Handynummer,
                        Bild = person.Bild,
                        Bild_Datei = person.Bild_Datei,
                        Bild_Name = person.Bild_Name,
                        Bild_Type = person.Bild_Type,
                        Beruf1_Id = profil.Beruf1_Id,
                        Beruf1_Name = profil.Beruf1_Name,
                        Erfahrung1 = profil.Erfahrung1,
                        Beruf2_Id = profil.Beruf2_Id,
                        Erfahrung2 = profil.Erfahrung2,
                        Abschlussart_Id = profil.Abschlussart_Id,
                        Studiengang_Id = profil.Studiengang_Id,
                        Einrichtung = profil.Einrichtung,
                        Studienort_Id = profil.Studienort_Id,
                        Anerkennung = profil.Anerkennung,
                        Deutsch = profil.Deutsch,
                        Niveau = profil.Niveau,
                        Englisch = profil.Englisch,
                        Zertifikate = profil.Zertifikate,
                        Persisch = profil.Persisch,
                        Fuehrerschein = profil.Fuehrerschein,
                        Anto = profil.Anto,
                        Einsatzwunsch = profil.Einsatzwunsch,
                        Lebenslauf = profil.Lebenslauf,
                        Lebenslauf_Datei = profil.Lebenslauf_Datei,
                        Lebenslauf_Name = profil.Lebenslauf_Name,
                        Lebenslauf_Type = profil.Lebenslauf_Type,
                        Bewerbung = profil.Bewerbung,
                        Bewerbung_Datei = profil.Bewerbung_Datei,
                        Bewerbung_Name = profil.Bewerbung_Name,
                        Bewerbung_Type = profil.Bewerbung_Type,
                        Sprachzertifikate = profil.Sprachzertifikate,
                        Sprachzertifikate_Datei = profil.Sprachzertifikate_Datei,
                        Sprachzertifikate_Name = profil.Sprachzertifikate_Name,
                        Sprachzertifikate_Type = profil.Sprachzertifikate_Type,
                        Studiumzertifikate = profil.Studiumzertifikate,
                        Studiumzertifikate_Datei = profil.Studiumzertifikate_Datei,
                        Studiumzertifikate_Name = profil.Studiumzertifikate_Name,
                        Studiumzertifikate_Type = profil.Studiumzertifikate_Type,
                        Arbeitserlaubnis = profil.Arbeitserlaubnis,
                        Ankunftsdatum = profil.Ankunftsdatum
                    })
                .Include(p => p.Beruf1_Id)
                .ToListAsync();
            
            return Ok(result);
            */
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BewerberProfilViewModel>> GetById(int id)
        {
            var person = await _context.Personen.FindAsync(id);
            if (person == null) return NotFound();

            var profil = await _context.Profile.FirstOrDefaultAsync(p => p.Person_Id == id);
            if (profil == null) return NotFound();

            var data = await _context.BewerberprofilModel.FirstOrDefaultAsync(p => p.Person_Id == id);
            var result = _mapper.Map<BewerberProfilViewModel>(data);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BewerberProfilViewModel vm)
        {
            var profil = await _context.Profile
                .Include(p => p.Person)
                .FirstOrDefaultAsync(p => p.Person_Id == id);

            if (profil == null)
                return NotFound();

            // Person-Daten aktualisieren
            var person = profil.Person;
            person.Anrede = vm.Anrede;
            person.Vorname = vm.Vorname;
            person.Nachname = vm.Nachname;
            person.Geburtstag = vm.Geburtstag;
            person.Geburtsort_Id = vm.Geburtsort_Id;
            person.Adresse = vm.Adresse;
            person.Laendercode = vm.Laendercode;
            person.Handynummer = vm.Handynummer;
            person.Bild = vm.Bild;
            person.Bild_Datei = vm.Bild_Datei;
            person.Bild_Name = vm.Bild_Name;
            person.Bild_Type = vm.Bild_Type;

            // Profil-Daten aktualisieren
            profil.Beruf1_Id = vm.Beruf1_Id;
            profil.Erfahrung1 = vm.Erfahrung1;
            profil.Beruf2_Id = vm.Beruf2_Id;
            profil.Erfahrung2 = vm.Erfahrung2;
            profil.Abschlussart_Id = vm.Abschlussart_Id;
            profil.Studiengang_Id = vm.Studiengang_Id;
            profil.Einrichtung = vm.Einrichtung;
            profil.Studienort_Id = vm.Studienort_Id;
            profil.Anerkennung = vm.Anerkennung;
            profil.Deutsch_Id = vm.Deutsch_Id;
            profil.Niveau_Id = vm.Niveau_Id;
            profil.Englisch_Id = vm.Englisch_Id;
            profil.Zertifikate_Id = vm.Zertifikate_Id;
            profil.Persisch_Id = vm.Persisch_Id;
            profil.Fuehrerschein_Id = vm.Fuehrerschein_Id;
            profil.Auto = vm.Auto;
            profil.Einsatzwunsch_Id = vm.Einsatzwunsch_Id;
            profil.Lebenslauf = vm.Lebenslauf;
            profil.Lebenslauf_Datei = vm.Lebenslauf_Datei;
            profil.Lebenslauf_Name = vm.Lebenslauf_Name;
            profil.Lebenslauf_Type = vm.Lebenslauf_Type;
            profil.Bewerbung = vm.Bewerbung;
            profil.Bewerbung_Datei = vm.Bewerbung_Datei;
            profil.Bewerbung_Name = vm.Bewerbung_Name;
            profil.Bewerbung_Type = vm.Bewerbung_Type;
            profil.Sprachzertifikate = vm.Sprachzertifikate;
            profil.Sprachzertifikate_Datei = vm.Sprachzertifikate_Datei;
            profil.Sprachzertifikate_Name = vm.Sprachzertifikate_Name;
            profil.Sprachzertifikate_Type = vm.Sprachzertifikate_Type;
            profil.Studiumzertifikate = vm.Studiumzertifikate;
            profil.Studiumzertifikate_Datei = vm.Studiumzertifikate_Datei;
            profil.Studiumzertifikate_Name = vm.Studiumzertifikate_Name;
            profil.Studiumzertifikate_Type = vm.Studiumzertifikate_Type;
            profil.Arbeitserlaubnis = vm.Arbeitserlaubnis;
            profil.Ankunftsdatum = vm.Ankunftsdatum;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BewerberProfilViewModel vm)
        {
            var person = new Person
            {
                Anrede = vm.Anrede,
                Vorname = vm.Vorname,
                Nachname = vm.Nachname,
                Geburtstag = vm.Geburtstag,
                Geburtsort_Id = vm.Geburtsort_Id,
                Adresse = vm.Adresse,
                Laendercode = vm.Laendercode,
                Handynummer = vm.Handynummer,
                Bild = vm.Bild,
                Bild_Datei = vm.Bild_Datei,
                Bild_Name = vm.Bild_Name,
                Bild_Type = vm.Bild_Type,
                Status = vm.Status,
                Erstellen_Date = DateTime.UtcNow,
                User_Id = vm.User_Id,
                Zuletzt_Aktiv_Date = DateTime.UtcNow
        };
            _context.Personen.Add(person);
            await _context.SaveChangesAsync();

            var profil = new Profil
            {
                Person_Id = person.Id,
                Beruf1_Id = vm.Beruf1_Id,
                Erfahrung1 = vm.Erfahrung1,
                Beruf2_Id = vm.Beruf2_Id,
                Erfahrung2 = vm.Erfahrung2,
                Abschlussart_Id = vm.Abschlussart_Id,
                Studiengang_Id = vm.Studiengang_Id,
                Einrichtung = vm.Einrichtung,
                Studienort_Id = vm.Studienort_Id,
                Anerkennung = vm.Anerkennung,
                Deutsch_Id = vm.Deutsch_Id,
                Niveau_Id = vm.Niveau_Id,
                Englisch_Id = vm.Englisch_Id,
                Zertifikate_Id = vm.Zertifikate_Id,
                Persisch_Id = vm.Persisch_Id,
                Fuehrerschein_Id = vm.Fuehrerschein_Id,
                Auto = vm.Auto,
                Einsatzwunsch_Id = vm.Einsatzwunsch_Id,
                Lebenslauf = vm.Lebenslauf,
                Lebenslauf_Datei = vm.Lebenslauf_Datei,
                Lebenslauf_Name = vm.Lebenslauf_Name,
                Lebenslauf_Type = vm.Lebenslauf_Type,
                Bewerbung = vm.Bewerbung,
                Bewerbung_Datei = vm.Bewerbung_Datei,
                Bewerbung_Name = vm.Bewerbung_Name,
                Bewerbung_Type = vm.Bewerbung_Type,
                Sprachzertifikate = vm.Sprachzertifikate,
                Sprachzertifikate_Datei = vm.Sprachzertifikate_Datei,
                Sprachzertifikate_Name = vm.Sprachzertifikate_Name,
                Sprachzertifikate_Type = vm.Sprachzertifikate_Type,
                Studiumzertifikate = vm.Studiumzertifikate,
                Studiumzertifikate_Datei = vm.Studiumzertifikate_Datei,
                Studiumzertifikate_Name = vm.Studiumzertifikate_Name,
                Studiumzertifikate_Type = vm.Studiumzertifikate_Type,
                Arbeitserlaubnis = vm.Arbeitserlaubnis,
                Ankunftsdatum = vm.Ankunftsdatum,
                Status = vm.Status,
                Erstellen_Date = DateTime.UtcNow,
                User_Id = vm.User_Id,
                Zuletzt_Aktiv_Date = DateTime.UtcNow
            };
            _context.Profile.Add(profil);
            await _context.SaveChangesAsync();

            return Ok(new { person.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profil = await _context.Profile.FirstOrDefaultAsync(p => p.Person_Id == id);
            if (profil != null)
                _context.Profile.Remove(profil);

            var person = await _context.Personen.FindAsync(id);
            if (person != null)
                _context.Personen.Remove(person);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
