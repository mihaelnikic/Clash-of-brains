using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RankingForms.ImplIgre.Answers;

namespace RankingForms.ImplIgre.Generators
{
    public class MockGenerator2 : IQuestionGenerator
    {
        private Dictionary<Kategorija, List<Question>> Questions;
        private List<Question> cache;
        private Random random;

        public MockGenerator2()
        {
            Questions = new Dictionary<Kategorija, List<Question>>();
            cache = new List<Question>(40);
            random = new Random();

            for (var i = Kategorija.Zemljopis; i <= Kategorija.Umjetnost; i++)
            {
                Questions.Add(i, new List<Question>());
            }

            //DODAVANJE PITANJA
            AddQuestion(new Question(1, "Koji je glavni grad Burkine Faso?",
                null, new ZaokruzivanjeAnswer("Ouagadougou", "Zagreb", "Honolulu", "Hong Kong", "Ouagadougou"), Kategorija.Zemljopis,
                "Afrièki gradovi"));
            AddQuestion(new Question(1, "Oznaèite zemlju na mapi u kojoj se nalazi MIT.",
                null, new MapaAnswer("United States"), Kategorija.Znanost,
                "Poznati fakulteti"));
            AddQuestion(new Question(1, "Koji je glavni grad Burkine Faso?",
                null, new ZaokruzivanjeAnswer("Ouagadougou", "Zagreb", "Honolulu", "Hong Kong", "Ouagadougou"), Kategorija.Zemljopis,
                "Afrièki gradovi"));


            AddQuestion(new Question(2, "Oznaèite zemlju na mapi u kojoj se nalazi MIT.",
                            null, new MapaAnswer("United States"), Kategorija.Znanost,
                            "Poznati fakulteti"));


            AddQuestion(new Question(3, "Oznaèite zemlju na mapi koja je poznata po fjordovima.",
                            null, new MapaAnswer("Norway"), Kategorija.Zemljopis,
                            "Prirodne ljepote"));

            AddQuestion(new Question(4, "Oznaèite zemlju u kojoj školska godina traje najduže.",
                            null, new MapaAnswer("Japan"), Kategorija.Zemljopis,
                            "Prirodne ljepote"));

            AddQuestion(new Question(5, "Koji je grad sjedište Katalonije?",
                            null, new ZaokruzivanjeAnswer("Barcelona", "Madrid", "Seville", "Granada", "Barcelona"), Kategorija.Zemljopis,
                            "Gradovi prijestolnice"));

            AddQuestion(new Question(6, "Kako glasi francuska rijeè za kanal?",
                            null, new ZaokruzivanjeAnswer("Le Canal", "Le Channel", "La manche", "La Canal", "La manche"), Kategorija.Zemljopis,
                            "Zemlje i jezici"));

            AddQuestion(new Question(7, "Latvija, Estonija, Litva i Letonija - koja dva od tih imena oznaèavaju istu državu?",
                            null, new ZaokruzivanjeAnswer("Latvija, Estonija", "Latvija, Litva", "Litva, Letonija", "Latvija, Letonija", "Latvija, Letonija"), Kategorija.Zemljopis,
                            "Europske države"));

            AddQuestion(new Question(8, "Koje je jedino mjesto na Zemlji na kojem voda vrije na 70 stupnjeva celzijusevih?",
                            null, new ZaokruzivanjeAnswer("Pustinja Sahara", "Vrh Mount Everesta", "Sjeverni pol", "TauTona rudnik", "Vrh Mount Everesta"), Kategorija.Znanost,
                            "Priroda i fenomeni"));

            AddQuestion(new Question(9, "Koje se slovo Morseovim kodom zapisuje s tri toèkice?",
                            null, new ZaokruzivanjeAnswer("F", "E", "R", "S", "S"), Kategorija.Tehnologija,
                            "Komunikacija i kodovi"));

            AddQuestion(new Question(10, "Uz šeæer, u procesu fotosinteze nastaje i?",
                            null, new ZaokruzivanjeAnswer("Sol", "Ugljik", "Kisik", "Dušik", "Kisik"), Kategorija.Znanost,
                            "Kemijske reakcije"));

            AddQuestion(new Question(10, "Uz šeæer, u procesu fotosinteze nastaje i?",
                            null, new ZaokruzivanjeAnswer("Sol", "Ugljik", "Kisik", "Dušik", "Kisik"), Kategorija.Znanost,
                            "Kemijske reakcije"));

            AddQuestion(new Question(11, "U kojem je talijanskom gradu prvi put zamirisala pizza?",
                            null, new ZaokruzivanjeAnswer("Rim", "Napulj", "Milano", "Rimini", "Napulj"), Kategorija.Zemljopis,
                            "Talijanska kuhinja"));

            AddQuestion(new Question(12, "Konzumacija èega je zabranjena u svemiru kad su Rusija i SAD poslali onamo zajednièku posadu 2000. godine?",
                            null, new ZaokruzivanjeAnswer("Kemijskih olovaka", "Upaljaèa", "Alkohola", "Mobitela", "Alkohola"), Kategorija.Zabava,
                            "Svemirska putovanja"));

            AddQuestion(new Question(13, "Koliko jedan kibibajt ima bitova?",
                            null, new ZaokruzivanjeAnswer("1000", "1024", "Ne postoji ta mjera", "1", "1024"), Kategorija.Tehnologija,
                            "Raèunalne jedinice"));

            AddQuestion(new Question(14, "Kako se Muhamed Ali zvao prije prijelaza na islam?",
                            null, new ZaokruzivanjeAnswer("Isto", "Cassius Clay", "Mike Tyson", "Manny Pacquiao", "Cassius Clay"), Kategorija.Zabava,
                            "Boksaèke ikone"));

            AddQuestion(new Question(15, "Miš i grafièko suèelje na raèunalu potekli su iz istraživaèkih pogona jedne tehnološke tvrtke koja nije proizvodila raèunala. Koje?",
                            null, new ZaokruzivanjeAnswer("Microsoft", "Apple", "IBM", "Xerox", "Xerox"), Kategorija.Tehnologija,
                            "Razvoj raèunala"));

            AddQuestion(new Question(16, "Oznaèite zemlju na mapi u kojoj se nalazi pustinja Atacama, najsušije mjesto na Zemlji.",
                            null, new MapaAnswer("Chile"), Kategorija.Zemljopis,
                            "Prirodni ekstremi"));

            AddQuestion(new Question(17, "Koje je èudo od svih antièkih sedam èuda sagraðeno prvo?",
                            null, new ZaokruzivanjeAnswer("Svjetionik u Aleksandriji, Egipat", "Viseèi vrtovi Babylona", "kip Zeusa na Olympiji, Grèka", "Keopsova piramida u Egiptu", "Keopsova piramida u Egiptu"), Kategorija.Povijest,
                            "Svjetska èuda"));

            AddQuestion(new Question(18, "Koji je najmanji kontinent?",
                            null, new ZaokruzivanjeAnswer("Afrika", "Australija", "Europa", "Južna Amerika", "Europa"), Kategorija.Zemljopis,
                            "Borba kontinenata"));

            AddQuestion(new Question(19, "Koja se životinja najviše spominje u Bibliji?",
                            null, new ZaokruzivanjeAnswer("Zmija", "Pas", "Ovca", "Ptica", "Ovca"), Kategorija.Umjetnost,
                            "Pogled u nebo"));

            AddQuestion(new Question(20, "Kako se u originalu zvala hrvatska himna Lijepa naša?",
                            null, new ZaokruzivanjeAnswer("Hrvatska ljepota", "Naša Hrvatska", "Lijepa Hrvatska", "Hrvatska domovina", "Hrvatska domovina"), Kategorija.Umjetnost,
                            "Himne"));

            AddQuestion(new Question(21, "U kojoj atletskoj disciplini natjecatelji moraju cijelo vrijeme dodirivati podlogu?",
                            null, new ZaokruzivanjeAnswer("Skok u vis", "Sprint na 100m", "Brzo hodanje", "Bacanje koplja", "Brzo hodanje"), Kategorija.Zabava,
                            "Sportske discipline"));

            AddQuestion(new Question(22, "Zašto je središnji ruski stožer za upravljanje projektilima privremeno bio izvan akcije 1995. godine?",
                            null, new ZaokruzivanjeAnswer("Nisu platili struju", "Ošteæeni generator", "Napuštena privremeno", "Obnavljanje", "Nisu platili struju"), Kategorija.Povijest,
                            "Vojna postrojenja"));

            AddQuestion(new Question(23, "Što se pojavilo 1913. godine u New Yorku i uzrokovalo da dok èitamo novine, u blizini imamo i olovku?",
                            null, new ZaokruzivanjeAnswer("Sudoku", "Križaljka", "Spajalica", "Bojanka", "Križaljka"), Kategorija.Povijest,
                            "Proboj u svakodnevici"));

            AddQuestion(new Question(24, "Što ne možete uopæe nabaviti u Japanu, a u SAD-u se proda jedan svakih 13,5 sekundi?",
                            null, new ZaokruzivanjeAnswer("dres NBA momèadi", "Kompjuter", "Snickers", "Pištolj", "Pištolj"), Kategorija.Zabava,
                            "Razlièitost kulture"));

            AddQuestion(new Question(25, "Francuska gastronomija godišnje potroši 25 000 tona gastropoda, ili drugim rijeèima?",
                            null, new ZaokruzivanjeAnswer("Krumpira", "Puževa", "Riba", "Matovilca", "Puževa"), Kategorija.Zabava,
                            "Veliki apetit"));

            AddQuestion(new Question(26, "Koja mnogoljudna država ima najviše fakulteta na svijetu?",
                            null, new ZaokruzivanjeAnswer("Indija", "Kanada", "Francuska", "Japan", "Indija"), Kategorija.Znanost,
                            "U znanju je spas"));

            AddQuestion(new Question(27, "Koje se carstvo u 14. stoljeæu prostiralo na 30 milijuna km kvadratna,površine kao 3 najveæe države danas?",
                            null, new ZaokruzivanjeAnswer("Tursko", "Mongolsko", "Kinesko", "Japansko", "Mongolsko"), Kategorija.Povijest,
                            "Bitka carstva"));

            AddQuestion(new Question(28, "Prva podzemna željeznica na svijetu otvorena je 1863. godine u kojem gradu?",
                            null, new ZaokruzivanjeAnswer("Beèu", "New Yorku", "Londonu", "Parizu", "Londonu"), Kategorija.Povijest,
                            "Transportna revolucija"));

            AddQuestion(new Question(29, "Koji amerièki predsjednik nedostaje spomeniku u Crnim brdima u Južnoj Dakoti: Lincoln, Roosevelt, Washington i...?",
                            null, new ZaokruzivanjeAnswer("Bush", "Clinton", "Jefferson", "Nixon", "Jefferson"), Kategorija.Povijest,
                            "Klesano u kamenu"));

            AddQuestion(new Question(30, "Tko je osvojio najviše medalja na jednim zimskim Olimpijskim igrama u disciplini alpsko skijanje?",
                            null, new ZaokruzivanjeAnswer("Hermann Maier", "Benjamin Raich", "Tina Maze", "Janica Kosteliæ", "Janica Kosteliæ"), Kategorija.Povijest,
                            "Olimpijske igre"));

            AddQuestion(new Question(31, "Pod kojim je nazivom poznat rat koji je trajao 116 godina?",
                            null, new ZaokruzivanjeAnswer("Stogodišnji rat", "Svjetski rat", "Križarski rat", "Stošesnaest godišnji rat", "Stogodišnji rat"), Kategorija.Povijest,
                            "Bitka do iznemoglosti"));

            AddQuestion(new Question(32, "Koji je španjolski diktator volio da ga zovu grandioznom titulom Generalissimus?",
                            null, new ZaokruzivanjeAnswer("benito mussolini", "Kim Jong-Il", "Francisco Franco", "Felipe VI of Spain", "Francisco Franco"), Kategorija.Povijest,
                            "Opasni diktatori"));

            AddQuestion(new Question(33, "Koja je pjevaèka zvijezda rekla da se neæe natjecati za mjesto predsjednika SAD-a jer mu se ne da seliti u manju kuæu?",
                            null, new ZaokruzivanjeAnswer("50 cent", "Bono", "Mick Jagger", "Elvis Presley", "Bono"), Kategorija.Zabava,
                            "Slava u glavu"));

            AddQuestion(new Question(34, "Kada biste putovali izmeðu dvije naudaljenije toèke Transsibirske željeznice, trebalo bi vam koliko dana?",
                            null, new ZaokruzivanjeAnswer("3", "5", "8", "10", "8"), Kategorija.Zabava,
                            "Daleka putovanja"));

            AddQuestion(new Question(34, "Kada biste putovali izmeðu dvije naudaljenije toèke Transsibirske željeznice, trebalo bi vam koliko dana?",
                            null, new ZaokruzivanjeAnswer("3", "5", "8", "10", "8"), Kategorija.Zabava,
                            "Daleka putovanja"));

            AddQuestion(new Question(35, "Koliko zapreka moraju preskoèiti trkaèi u utrci na 110m s preponama?",
                            null, new ZaokruzivanjeAnswer("8", "9", "10", "11", "10"), Kategorija.Zabava,
                            "Trèi do pobjede"));

            AddQuestion(new Question(36, "Koja je bila prva prava i dugo najpopularnija FPS raèunalna igra?",
                            null, new ZaokruzivanjeAnswer("DOOM", "Counter strike", "Call of Duty", "Battlefield", "DOOM"), Kategorija.Zabava,
                            "Raèunalne igre"));

            AddQuestion(new Question(37, "Koliko je èlanova Prstenove družine pripadalo hobitima?",
                            null, new ZaokruzivanjeAnswer("2", "3", "4", "5", "4"), Kategorija.Umjetnost,
                            "Sedma umjetnost - Film"));

            AddQuestion(new Question(38, "Ako se motor vrti brzinom 3000 okretaja u minuti, koliko okretaja za to vrijeme napravi klip u motoru?",
                            null, new ZaokruzivanjeAnswer("3000", "500", "0", "60", "0"), Kategorija.Tehnologija,
                            "Motorna vozila"));

            AddQuestion(new Question(39, "Na kojoj je relaciji izgraðena prva hrvatska željeznièka pruga?",
                            null, new ZaokruzivanjeAnswer("Zagreb - Rijeka", "Zagreb - Karlovac", "Zagreb - Sisak", "Glavni kolodvor - Dubrava", "Zagreb - Sisak"), Kategorija.Povijest,
                            "Choo - Choo!"));

            AddQuestion(new Question(40, "Medica se radi od meda, travarica od trava, viljamovka od krušaka, a tekila od?",
                            null, new ZaokruzivanjeAnswer("Agave", "Trešanja", "Šljiva", "Slame", "Agave"), Kategorija.Zabava,
                            "U piæu je spas"));

            AddQuestion(new Question(41, "Što se nalazilo u kutu zastave SAD-a sve do 14. lipnja 1777. godine?",
                            null, new ZaokruzivanjeAnswer("Oduvijek su zvijezdice", "Jedna zvijezda", "Britanska zastava", "Stilizirani rakun", "Britanska zastava"), Kategorija.Povijest,
                            "Zastave"));

            AddQuestion(new Question(42, "Što u havajskom jeziku zajedno èine A, E, I, K, L, M, N, O, P, U, W?",
                            null, new ZaokruzivanjeAnswer("Nepostojeæa slova", "Slova sa posebnom intonacijom", "Cjelokupni alfabet", "Latiniæna slova alfabeta", "Cjelokupni alfabet"), Kategorija.Zabava,
                            "Prièaš moj jezik?"));

            AddQuestion(new Question(43, "Èega se plaše ablutofobi?",
                            null, new ZaokruzivanjeAnswer("Visina", "Kupanja tj. pranja", "Mraka", "Dubina", "Kupanja tj. pranja"), Kategorija.Zabava,
                            "Nema straha?"));

            AddQuestion(new Question(44, "Koja mjera ima 2,54 centimetra?",
                            null, new ZaokruzivanjeAnswer("Col ili inè", "Stopa", "Jarda", "Milja", "Col ili inè"), Kategorija.Tehnologija,
                            "Kako to rade Amerikanci"));

            AddQuestion(new Question(45, "Kako glasi registarska oznaka za vozila iz Ðakova?",
                            null, new ZaokruzivanjeAnswer("ÐA", "DJ", "ÐK", "DA", "DJ"), Kategorija.Zabava,
                            "Registarske oznake"));

            AddQuestion(new Question(46, "Što je H5N1 i može prijeæi s ptica na ljude?",
                            null, new ZaokruzivanjeAnswer("Bakterija", "Virus", "Perje", "pismo ptica pismonoša", "Virus"), Kategorija.Zabava,
                            "Životinje i ljudi"));

            AddQuestion(new Question(47, "Što ubija bakterije u pasterizaciji?",
                            null, new ZaokruzivanjeAnswer("Toplina", "Tlak", "Struja", "Vakum", "Toplina"), Kategorija.Tehnologija,
                            "Industrijski procesi"));

            AddQuestion(new Question(48, "Što oznaèava kratica RNA?",
                            null, new ZaokruzivanjeAnswer("Rapidna nukleinska aktivacija", "Robusna N-pojava", "Right now action", "Ribonukleinska kiselina", "Ribonukleinska kiselina"), Kategorija.Znanost,
                            "Skrati malo"));

            AddQuestion(new Question(49, "Sa Koliko godina je Napoleon postao francuki general?",
                            null, new ZaokruzivanjeAnswer("20", "26", "31", "36", "26"), Kategorija.Povijest,
                            "Vojskovoðe i heroji"));

            AddQuestion(new Question(50, "Koji je organ u ljudskom tijelu Aristotel oznaèio kao središte inteligencije?",
                            null, new ZaokruzivanjeAnswer("Srce", "Mozak", "Želudac", "Jezik", "Srce"), Kategorija.Povijest,
                            "Grèki mislioci"));

            AddQuestion(new Question(51, "Sok kojeg ploda se može upotrijebiti umjesto krvne plazme u hitnim sluèajevima?",
                            null, new ZaokruzivanjeAnswer("Jabuke", "Ananasa", "Kokosova oraha", "Naranèe", "Kokosova oraha"), Kategorija.Znanost,
                            "Medicina"));

            AddQuestion(new Question(52, "Kakve su restrikcije postavljene na duljinu motke koju koriste skakaèi s motkom?",
                            null, new ZaokruzivanjeAnswer("5 metara", "5.5 metara", "6 metara", "Nikakve", "Nikakve"), Kategorija.Zabava,
                            "Sportska regulacija"));

            AddQuestion(new Question(53, "Koji metal prelazi u kruto stanje na -40 stupnjeva celzijusevih?",
                            null, new ZaokruzivanjeAnswer("Aluminij", "Natrij", "Kalij", "Živa", "Živa"), Kategorija.Znanost,
                            "Kemijski elementi"));

            AddQuestion(new Question(54, "Èega prosjeèni komarac ima 47?",
                            null, new ZaokruzivanjeAnswer("Krila", "Nogu", "Zubi", "Oèi", "Zubi"), Kategorija.Znanost,
                            "Životinjski svijet"));

            AddQuestion(new Question(55, "Koju eksplozivnu tvar srèani bolesnici ponekad drže pod jezikom?",
                            null, new ZaokruzivanjeAnswer("Natrij", "Nitroglicerin", "Dinamit", "Kalij", "Nitroglicerin"), Kategorija.Znanost,
                            "Zdravlje"));

            AddQuestion(new Question(56, "Koju planetu Kinezi smatraju metalnom zvijezdom?",
                            null, new ZaokruzivanjeAnswer("Mars", "Merkur", "Veneru", "Jupiter", "Veneru"), Kategorija.Znanost,
                            "Planeti"));

            AddQuestion(new Question(57, "Prosjeèan Indijanac s podruèja Anda ima 1,6litara veæu zapremninu kojeg tjelesnog organa?",
                            null, new ZaokruzivanjeAnswer("Želuca", "Crijeva", "Pluæa", "Srca", "Pluæa"), Kategorija.Znanost,
                            "Ljudski ekstremi"));

            AddQuestion(new Question(58, "Koliko krugova ima pakao u Božanstvenoj komediji autora Dantea?",
                            null, new ZaokruzivanjeAnswer("3", "6", "9", "12", "9"), Kategorija.Umjetnost,
                            "Knjiske avanture"));

            AddQuestion(new Question(59, "Koji je skladatelj tijekom života oglušio, a to ga nije sprjeèilo u svojem djelovanju?",
                            null, new ZaokruzivanjeAnswer("Wolfgang Amadeus Mozart", "Johannes Brahms", "Ludwig van Beethoven", "Franz Liszt", "Ludwig van Beethoven"), Kategorija.Umjetnost,
                            "Skladatelji"));

            AddQuestion(new Question(60, "Tko je autor popularnih baleta Labuðe jezero i Orašar?",
                            null, new ZaokruzivanjeAnswer("Adolphe Adam", "Pyotr Ilyich Tchaikovsky", "Sergei Prokofiev", "Felix Mendelssohn", "Pyotr Ilyich Tchaikovsky"), Kategorija.Umjetnost,
                            "Balet"));

            AddQuestion(new Question(61, "Oznaèite zemlju na mapi u kojoj je roðen Franz Liszt.",
                            null, new MapaAnswer("Hungary"), Kategorija.Umjetnost,
                            "Kompozitori"));


            AddQuestion(new Question(62, "Oznaèite zemlju na mapi u kojoj je roðen Wolfgang Amadeus Mozart.",
                            null, new MapaAnswer("Austria"), Kategorija.Umjetnost,
                            "Kompozitori"));

            AddQuestion(new Question(63, "Oznaèite zemlju na mapi u kojoj je roðen Ludwig van Beethoven.",
                            null, new MapaAnswer("Germany"), Kategorija.Umjetnost,
                            "Kompozitori"));

            AddQuestion(new Question(64, "Oznaèite zemlju na mapi koja je poznata po minijaturnim drvima Bonsai.",
                            null, new MapaAnswer("Japan"), Kategorija.Umjetnost,
                            "Kompozitori"));

            AddQuestion(new Question(65, "Tko je od ponuðenih osvojio najviše zlatnih kipiæa, Oskara?",
                            null, new ZaokruzivanjeAnswer("Meryl Streep", "Katharine Hepburn", "Robert De Niro", "Dustin Hoffman", "Katharine Hepburn"), Kategorija.Umjetnost,
                            "Filmske zvijezde"));

            AddQuestion(new Question(66, "Koji je najskuplji film dosad snimljen?",
                            null, new ZaokruzivanjeAnswer("Pirati s Kariba: nepoznate plime", "Harry Potter: Plameni pehar", "Gospodar prstenova: Prstenova družina", "Avatar", "Pirati s Kariba: nepoznate plime"), Kategorija.Umjetnost,
                            "Filmovi"));

            AddQuestion(new Question(67, "Oznaèite zemlju na mapi u kojoj se održavaju ljetne Olimpijske igre 2016 godine.",
                            null, new MapaAnswer("Brasil"), Kategorija.Zemljopis,
                            "Zemlje domaèini igara"));

            AddQuestion(new Question(68, "Oznaèite zemlju na mapi u kojoj je Hrvatska ostvarila najveæi nogometni uspjeh 1998 godine na 1998 FIFA World Cup-u.",
                            null, new MapaAnswer("France"), Kategorija.Zemljopis,
                            "Zemlje domaèini igara"));

            AddQuestion(new Question(69, "Oznaèite zemlju na mapi iz koje potjeèe poznati proizvoðaè namještaja, poznat po plavo žutoj boji.",
                            null, new MapaAnswer("Sweden"), Kategorija.Zemljopis,
                            "Porijeklo velikana"));

            AddQuestion(new Question(70, "Oznaèite zemlju na mapi u kojoj se održava poznati teniski turnir Wimbledon.",
                            null, new MapaAnswer("England"), Kategorija.Zemljopis,
                            "Zemlje domaèini igara"));

            AddQuestion(new Question(71, "Koja je država krajem osamdesetih usporedno držala titule svjetskih omladinskih prvaka u nogometu, košarci, rukometu i vaterpolu?",
                            null, new ZaokruzivanjeAnswer("SAD", "Zapadna Njemaèka", "Engleska", "Jugoslavija", "Jugoslavija"), Kategorija.Povijest,
                            "Zemlje prvakinje"));

            AddQuestion(new Question(72, "Po èemu je crkveni zvonik u njemaèkom Ulmu prvi u Europi?",
                            null, new ZaokruzivanjeAnswer("Po starosti", "Po renesansnom stilu gradnje", "Po visini", "Po debljini", "Po visini"), Kategorija.Umjetnost,
                            "Graðevine"));

            AddQuestion(new Question(73, "Koje je voæe 2005. godine zabranjeno uvoziti iz Iraka u Kuvajt zbog opasnosti da u njemu krijumèare eksploziv ili drogu?",
                            null, new ZaokruzivanjeAnswer("Lubenice", "Kokos", "Bundeve", "Ananas", "Lubenice"), Kategorija.Zabava,
                            "Voæe"));

            AddQuestion(new Question(74, "Izmeðu èega su u povijesti nastupali interglacijali?",
                            null, new ZaokruzivanjeAnswer("Izmeðu punog mjeseca", "Izmeðu prijestupnih godina", "Izmeðu ledenih doba", "Izmeðu ratnih razdoblja", "Izmeðu ledenih doba"), Kategorija.Znanost,
                            "Struèni termini"));

            AddQuestion(new Question(75, "Što je neobièno u šampanjcu kojim nazdravljaju pobjednici utrke Formule 1 u Bahreinu?",
                            null, new ZaokruzivanjeAnswer("Nije gaziran", "Topli je", "Bezalkoholan je", "Ne piju ga", "Bezalkoholan je"), Kategorija.Zabava,
                            "Dodjela nagrada"));

            AddQuestion(new Question(76, "Koji planet je dva i pol puta veæi od svega ostalog što se okreæe oko sunca?",
                            null, new ZaokruzivanjeAnswer("Jupiter", "Saturn", "Uran", "Zemlja", "Jupiter"), Kategorija.Znanost,
                            "Planeti"));

            AddQuestion(new Question(77, "Koja je republika ukinula ropstvo 449 godina prije SAD-a?",
                            null, new ZaokruzivanjeAnswer("Dubrovaèka republika", "Portugal", "Engleska", "Turska", "Dubrovaèka republika"), Kategorija.Povijest,
                            "Robstvo"));

            AddQuestion(new Question(78, "Kako se zvala prva klonirana ovca?",
                            "http://www.deviantpics.com/images/2016/05/25/sheep.jpg", new ZaokruzivanjeAnswer("Molly", "Jolly", "Dolly", "Clyde", "Dolly"), Kategorija.Znanost,
                            "Genetika"));

            AddQuestion(new Question(79, "Što je Australcima 1989. godine ponovno dozvoljeno jesti nakon stogodišnje zabrane?",
                            null, new ZaokruzivanjeAnswer("Morske pse", "Školjke", "Mungose", "Klokane", "Klokane"), Kategorija.Povijest,
                            "Meniji iz prošlosti"));

            AddQuestion(new Question(80, "Kako je lik koji igra Leonardo DiCaprio zaradio kartu za Titanic u istoimenom filmu?",
                            null, new ZaokruzivanjeAnswer("Konobario je", "Štedio", "Dobio na pokeru", "Na prevaru", "Dobio na pokeru"), Kategorija.Umjetnost,
                            "Filmski likovi"));

            AddQuestion(new Question(81, "U kojoj zgradi je 8.10.1991. održano zasjedanje Sabora na kojem je proglašena hrvatska neovistnos?",
                            null, new ZaokruzivanjeAnswer("Ina Naftaplina", "U Banskim dvorima", "HEP-a", "FER-a", "Ina Naftaplina"), Kategorija.Povijest,
                            "Hrvatska povijest"));

            AddQuestion(new Question(82, "Koju je društvenu igru Castro zabranio na Kubi i naredio uništenje svih primjeraka?",
                            null, new ZaokruzivanjeAnswer("Rizik", "Monopoly", "Èovjeèe, ne ljuti se", "Igra života", "Monopoly"), Kategorija.Zabava,
                            "Društvene igre"));
            AddQuestion(new Question(83, "Oznaèite zemlju na mapi koja je poznata po vjetrenjaèama i uzgoju tulipana.",
                            "http://www.deviantpics.com/images/2016/05/25/tulips.jpg", new MapaAnswer("Netherlands"), Kategorija.Zemljopis,
                            "Europske države"));
            AddQuestion(new Question(84, "Na koja dva kontinenta nikad nije bilo ratova?",
                            null, new ZaokruzivanjeAnswer("Azija i Južna Amerika", "Južna Amerika i Antarktika", "Južna Amerika i Australija", "Australija i Antarktika", "Australija i Antarktika"), Kategorija.Povijest,
                            "Ratovi"));
            AddQuestion(new Question(85, "Koliko su godina Britanci držali Hong Kong?",
                            null, new ZaokruzivanjeAnswer("90", "99", "100", "101", "99"), Kategorija.Povijest,
                            "Kolonije"));
            AddQuestion(new Question(86, "Koliko se manjih kopija-satelita nalazi po Zagrebu, uokolo Kožariæeve skulpture Prizemljeno Sunce?",
                            null, new ZaokruzivanjeAnswer("5", "7", "3", "9", "9"), Kategorija.Umjetnost,
                            "Kiparstvo"));
            AddQuestion(new Question(87, "Kako glasi kemijska formula èistog leda?",
                            null, new ZaokruzivanjeAnswer("H2O2", "H2O", "HO", "LeD", "H2O"), Kategorija.Znanost,
                            "Kemijski spojevi"));
            AddQuestion(new Question(88, "Koji je kipar prvi u povijesti imao samostalnu izložbu u njujorškom muzeju Metropolitan?",
                            null, new ZaokruzivanjeAnswer("Ivan Meštroviæ", "Damian Ortega", "Antony Gormley", "Lynda Benglis", "Ivan Meštroviæ"), Kategorija.Umjetnost,
                            "Kiparstvo"));
            AddQuestion(new Question(89, "Koji je najstariji kukac na planetu vlasnik potpuno bajkovitog imena?",
                            null, new ZaokruzivanjeAnswer("Vilin konjic", "Pèela", "Bubamara", "Jelenak", "Vilin konjic"), Kategorija.Znanost,
                            "Stare životinje"));
            AddQuestion(new Question(90, "Koji je poslijednji državnik koji je bio u posjetu papi Ivanu Pavlu II.?",
                            null, new ZaokruzivanjeAnswer("George Bush", "Ivo Sanader", "David Cameron", "Jacques Chirac", "Ivo Sanader"), Kategorija.Povijest,
                            "Državnici"));
            AddQuestion(new Question(91, "Što mjerimo jedinicom zvanom Tesla?",
                            "http://www.deviantpics.com/images/2016/05/25/tesla.png", new ZaokruzivanjeAnswer("Magnetski tok", "Magnetsku indukciju", "Snagu", "Jaèinu struje", "Magnetsku indukciju"), Kategorija.Znanost,
                            "Fizikalne velièine"));
            AddQuestion(new Question(92, "Što mjerimo svjetlosnom godinom",
                            null, new ZaokruzivanjeAnswer("Vrijeme", "Daljinu", "Snagu", "Brzinu", "Daljinu"), Kategorija.Znanost,
                            "Fikalne velièine"));
            AddQuestion(new Question(93, "Oznaèite zemlju na mapi iz koje potjeæu èuvene LEGO kocke.",
                null, new MapaAnswer("Denmark"), Kategorija.Zemljopis,
                "Europske države"));
            AddQuestion(new Question(93, "Oznaèite zemlju na mapi iz koje potjeæu èuvene LEGO kocke.",
                null, new MapaAnswer("Denmark"), Kategorija.Zemljopis,
                "Europske države"));
            AddQuestion(new Question(94,
                "Oznaèite zemlju na mapi koja se prostire na dva kontinenta, a dijele ju Bospor i Dardaneli.",
                null, new MapaAnswer("Turkey"), Kategorija.Zemljopis,
                "Države"));
            AddQuestion(new Question(95,
                "Oznaèite iskljuèivo europsku zemlju na mapi koja ima najviše nacionalnih parkova.",
                null, new MapaAnswer("Finland"), Kategorija.Zemljopis,
                "Europske države"));
            AddQuestion(new Question(96, "Koji je od navedenih slikara porijeklom iz Španjolske?",
                null, new ZaokruzivanjeAnswer("Vincent van Gogh", "Rembrandt", "Claude Monet", "Salvador Dali", "Salvador Dali"), Kategorija.Umjetnost,
                "Slikari"));

            AddQuestion(new Question(97, "Koja je naša spisateljica 1931. i 1938. godine predlagana za Nobelovu nagradu?",
                            null, new ZaokruzivanjeAnswer("Marijana Palatin", "Ivana Brliæ-Mažuraniæ", "Doroteja Lipkoviæ", "Dubravka Ugrešiæ", "Ivana Brliæ-Mažuraniæ"), Kategorija.Umjetnost,
                            "Spisateljice"));

            AddQuestion(new Question(98, "S kojim nebeskim tijelom povezujemo Beethovenovu Sonatu za klavir u Cis-molu, op.27, br.2?",
                            null, new ZaokruzivanjeAnswer("Mjesec", "Venera", "Mars", "Zvijezde", "Mjesec"), Kategorija.Umjetnost,
                            "Skladbe"));











        }
        public List<Question> GenerateNextQuestions()
        {
            if (cache.Count > 40)
            {
                for (int i = 0; i < 25; i++)
                {
                    Questions[cache.ElementAt(0).Kategorija].Add(cache.ElementAt(0));
                    cache.RemoveAt(0);
                }
            }
            List<Question> questionsList = new List<Question>(4);
            var values = Enumerable.Range(1, 6).OrderBy(x => random.Next()).ToArray();

            for (int i = 0; i < 4; i++)
            {
                Question q;
                if (Questions[(Kategorija) values[i]].Count < 1)
                {
                    q = cache.First(question => question.Kategorija == (Kategorija) values[i]);
                }
                else
                {
                    var qList = Questions[(Kategorija)values[i]];
                    int indexPitanja = random.Next(0, qList.Count);
                    q = qList[indexPitanja];
                    qList.RemoveAt(indexPitanja);
                    cache.Add(q);
                }
                questionsList.Add(q);
            }
            return questionsList;
        }


        private void AddQuestion(Question q) 
        {
            Questions[q.Kategorija].Add(q);
        }


        public void Clear()
        {
            
        }
    }
}