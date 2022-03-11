﻿using System.Collections.Concurrent;
using System.Net;

ConcurrentQueue<DateTime> q = new();
void Enque()
{
    if (q.Count >= 900000)
    {
        q.TryDequeue(out DateTime _);
    }
    q.Enqueue(DateTime.Now);
}

using CancellationTokenSource cts = new ();
CancellationToken cancellationToken = cts.Token;
var secondsStatPrint = 10;
var ts = TimeSpan.FromSeconds(secondsStatPrint);
var timer = new PeriodicTimer(ts);

await Task.Delay(15000);
var t = Task.Run(async () =>
{
    int timerTicks = 0;
    while(!cancellationToken.IsCancellationRequested)
    {
        await timer.WaitForNextTickAsync();
        try
        {
            timerTicks++;
            var cnt = q.Count(i => i > DateTime.Now - ts) / secondsStatPrint;
            Console.Write($"\r{cnt}\t{q.Count()}\t{(timerTicks * ts).TotalSeconds}\t\t");
        }
        catch { }
    }
});

List<string> cities = new()
{
    "cit_I",
    "cit_A",
    "cit_E",
    "cit_Y",
    "cit_O",
    "cit_U",
    "cit_Er",
    "cit_Up",
    "cit_Af",
    "cit_Eb",
    "cit_Ix",
    "cit_Oc",
    "cit_Oq",
    "cit_Oj",
    "cit_Am",
    "cit_Ud",
    "cit_Aw",
    "cit_Or",
    "cit_Ys",
    "cit_Ug",
    "cit_Ih",
    "cit_Az",
    "cit_Ux",
    "cit_Us",
    "cit_Eg",
    "cit_Is",
    "cit_Iw",
    "cit_Yg",
    "cit_Ik",
    "cit_Ej",
    "cit_Ob",
    "cit_Yb",
    "cit_Od",
    "cit_Ow",
    "cit_Os",
    "cit_Yq",
    "cit_Ah",
    "cit_Yl",
    "cit_Ec",
    "cit_Id",
    "cit_Ig",
    "cit_Ot",
    "cit_Ab",
    "cit_Il",
    "cit_Ox",
    "cit_Yx",
    "cit_Yh",
    "cit_Yw",
    "cit_Iq",
    "cit_Ar",
    "cit_Es",
    "cit_I U",
    "cit_At",
    "cit_Of",
    "cit_Ed",
    "cit_Yz",
    "cit_Ir",
    "cit_Ul",
    "cit_Yf",
    "cit_Ok",
    "cit_Et",
    "cit_Yn",
    "cit_Yk",
    "cit_Ip",
    "cit_Ap",
    "cit_It",
    "cit_Ef",
    "cit_U I",
    "cit_Ev",
    "cit_A O",
    "cit_Ew",
    "cit_Ile",
    "cit_Uz",
    "cit_Om",
    "cit_Yd",
    "cit_Ub",
    "cit_Uc",
    "cit_Uj",
    "cit_Ur",
    "cit_U U",
    "cit_Ex",
    "cit_Ak",
    "cit_Uf",
    "cit_Y A",
    "cit_Yp",
    "cit_Idu",
    "cit_Ym",
    "cit_Uza",
    "cit_Al",
    "cit_O E",
    "cit_E E",
    "cit_Ez",
    "cit_Ebi",
    "cit_Ojo",
    "cit_Uk",
    "cit_As",
    "cit_Yr",
    "cit_A E",
    "cit_Oh",
    "cit_Ut",
    "cit_On",
    "cit_Yj",
    "cit_Op",
    "cit_Iqa",
    "cit_Ib",
    "cit_Ad",
    "cit_E A",
    "cit_Agu",
    "cit_Aq",
    "cit_I I",
    "cit_Ij",
    "cit_Iz",
    "cit_Ypo",
    "cit_Yxa",
    "cit_Ega",
    "cit_Yqu",
    "cit_Ax",
    "cit_Uh",
    "cit_An",
    "cit_Isy",
    "cit_Ere",
    "cit_Awa",
    "cit_Uv",
    "cit_Ybo",
    "cit_Avi",
    "cit_In",
    "cit_Av",
    "cit_Eza",
    "cit_Ohe",
    "cit_O Y",
    "cit_En",
    "cit_A U",
    "cit_Un",
    "cit_Ani",
    "cit_Yc",
    "cit_Uq",
    "cit_Ac",
    "cit_Ote",
    "cit_Um",
    "cit_Elu",
    "cit_Ape",
    "cit_I A",
    "cit_Oz",
    "cit_Ada",
    "cit_Ami",
    "cit_Og",
    "cit_Em",
    "cit_Ide",
    "cit_Ody",
    "cit_Ume",
    "cit_Epa",
    "cit_Ep",
    "cit_Ek",
    "cit_Uge",
    "cit_Ywa",
    "cit_Ale",
    "cit_Ol",
    "cit_Eda",
    "cit_U Y",
    "cit_A I",
    "cit_Uba",
    "cit_O Ux",
    "cit_Ema",
    "cit_I E",
    "cit_O U",
    "cit_One",
    "cit_Uvu",
    "cit_El",
    "cit_Uky",
    "cit_Otu",
    "cit_Yna",
    "cit_Oby",
    "cit_Epypaj Roc M",
    "cit_Idi",
    "cit_Yle",
    "cit_U A",
    "cit_Emo",
    "cit_Oce",
    "cit_Y I",
    "cit_Ine",
    "cit_E O",
    "cit_Ace",
    "cit_Odo",
    "cit_Oxa",
    "cit_Uta",
    "cit_Ase",
    "cit_Edu",
    "cit_Omu",
    "cit_Ury",
    "cit_Yhi",
    "cit_Yxug",
    "cit_Usi",
    "cit_Uryw",
    "cit_Ive",
    "cit_Uwi",
    "cit_A Ubacekec C",
    "cit_Ic",
    "cit_Aga",
    "cit_Eduh Rozy",
    "cit_Ofe",
    "cit_Ode",
    "cit_Umew",
    "cit_Yve",
    "cit_Ose",
    "cit_Ygi",
    "cit_Oqu",
    "cit_Evyla Ujed",
    "cit_Oru",
    "cit_I Iz L",
    "cit_Ubo",
    "cit_Udy",
    "cit_Ypilezykitajyx",
    "cit_A Y",
    "cit_Aj",
    "cit_Ufa",
    "cit_Yxadapeton Qaci",
    "cit_Oco",
    "cit_Iba",
    "cit_Epo",
    "cit_Ita",
    "cit_Ywiwa Ono",
    "cit_U Ujyh",
    "cit_Ole",
    "cit_Eke",
    "cit_Edikef",
    "cit_Uw",
    "cit_Era",
    "cit_Ajaku I",
    "cit_Ufi",
    "cit_Yta",
    "cit_Ozy",
    "cit_I I A A Ic",
    "cit_Yno",
    "cit_Aly",
    "cit_Ajo",
    "cit_Uwy",
    "cit_Ujy",
    "cit_Owu",
    "cit_Ozo",
    "cit_Ylol",
    "cit_Ofumikukemitige",
    "cit_Ygedeqal Siqicy",
    "cit_Akyf",
    "cit_Ery",
    "cit_Iji",
    "cit_Ivyniler",
    "cit_A I El Mutiredipu",
    "cit_Uva Ucelidip",
    "cit_Eva",
    "cit_Id Be",
    "cit_Ofobe E",
    "cit_A Or",
    "cit_Et Qyjaduvohu Ah",
    "cit_Opina Epime",
    "cit_Oje",
    "cit_Axigigusisupic Q",
    "cit_Yq W",
    "cit_Ejecen",
    "cit_Isusatuvekafuvaz",
    "cit_Ycihe Evo",
    "cit_Et Va Ewefuxir",
    "cit_Eqimy",
    "cit_Yje",
    "cit_Utuboqyfaha",
    "cit_Asup",
    "cit_Ucufa",
    "cit_Evelavitiz",
    "cit_Oju",
    "cit_Ulo Awo",
    "cit_A Y Uqe",
    "cit_Itafadaqiryfe",
    "cit_Ap Voce",
    "cit_Uceqefavakalyrucim",
    "cit_Ilokeqijidit Bori",
    "cit_Amogoqajutad",
    "cit_Ytedit",
    "cit_Ycu",
    "cit_Olu",
    "cit_Uwo",
    "cit_Abidejy",
    "cit_U Owatacaf J Ses",
    "cit_Exug",
    "cit_Iwegymahumuwi",
    "cit_A Ywabysakywyc Raf",
    "cit_Ajac R Zav Mafer",
    "cit_Ora",
    "cit_Epoh Lymubutefa",
    "cit_E Ywalyk C Niqejew",
    "cit_O Etom",
    "cit_Upawe Ak",
    "cit_Ali",
    "cit_Ox Fuma Ek Z",
    "cit_Yqyfurubokihel",
    "cit_Osaxujat",
    "cit_O U Oh",
    "cit_Epa E U Uj",
    "cit_Eqiced",
    "cit_Igyj",
    "cit_Ujalumatusog",
    "cit_Akakukowodadewavo",
    "cit_Iselekavufalolumeg",
    "cit_Apejyjy Y",
    "cit_Yqov P Penetak",
    "cit_Uwuhumyjo",
    "cit_Ojipus",
    "cit_E Ifapat",
    "cit_Ajabyc Qep",
    "cit_O Yquric Jo Y U",
    "cit_If",
    "cit_Igupev",
    "cit_Odiq",
    "cit_Esabepererit Kawe",
    "cit_Ykap N",
    "cit_Epigyxyja Ady",
    "cit_Uqov",
    "cit_Ekipo",
    "cit_Uzoda Afet Le",
    "cit_Ebez",
    "cit_Ocumade",
    "cit_Is Su",
    "cit_Ubenapozala",
    "cit_Eqo E Ibowuwy",
    "cit_Upix",
    "cit_Umo",
    "cit_Ujeposyqavabywy",
    "cit_Ubufake",
    "cit_Ydihalagoqybeset",
    "cit_Ogi Iwu",
    "cit_Ysitil",
    "cit_Isah",
    "cit_Atufogozypytesuw",
    "cit_Oruc Fe U",
    "cit_Aj Ja I",
    "cit_Eve",
    "cit_Igikiduw Zar",
    "cit_Yfe",
    "cit_Ylumyf Cuv",
    "cit_Onos Suk",
    "cit_Ag",
    "cit_Aku Ifor",
    "cit_Ekedalapip Pi It",
    "cit_Udores G Viboq",
    "cit_Iho",
    "cit_Ilafar Sa Uka",
    "cit_Owifali Akysafyp",
    "cit_Yhegoj Kyr J",
    "cit_Y Avu",
    "cit_Iceduleqowe",
    "cit_Uvaxevoqefihera",
    "cit_Ymukuqynic Xabotor",
    "cit_Owete Yfik G",
    "cit_Uta Ukaxylol L",
    "cit_Ete Odabyfoga",
    "cit_Isasyqa Obywi",
    "cit_Ore Ifu Um Waciz X",
    "cit_Ubovahojagyh",
    "cit_Em Dehogohatasym C",
    "cit_I Ufir Ki",
    "cit_Awelavawify O",
    "cit_Ivetarydyw Gyx Fi",
    "cit_Ucy Ydupa E",
    "cit_E Ojebok",
    "cit_Eqiz",
    "cit_Ine Abyj",
    "cit_Im",
    "cit_Epimyj",
    "cit_Ytata",
    "cit_Ix N Fejuvoryk",
    "cit_Yv",
    "cit_Ujuqidikudojuzoqal",
    "cit_Otaveqynycunake",
    "cit_Avu",
    "cit_Yma",
    "cit_Ywab Poco",
    "cit_Ubaju Ewa E Awef",
    "cit_Etalawusi Oc J W",
    "cit_Irenuvar",
    "cit_Igeveqy Asyxiroqy",
    "cit_Opy",
    "cit_Iwem",
    "cit_Inejibypama",
    "cit_Atugohy",
    "cit_Isun Ritaka",
    "cit_Ucedeqosa Ic",
    "cit_Aqis Ve",
    "cit_Aqepufuhar",
    "cit_U Asy Inyzalim",
    "cit_Ilelegyna Yxuquq",
    "cit_Yw Xaho Up",
    "cit_Ogu",
    "cit_Ylezelawuko Icuj",
    "cit_Axifeg",
    "cit_U Azur Qiqo",
    "cit_Ow Xyc",
    "cit_Ykam X",
    "cit_Iwewozite Y Ubew",
    "cit_Ifi Obuqa",
    "cit_Ym Pa Utubapywyca",
    "cit_Ag Ja",
    "cit_Iwipimywywifydeho",
    "cit_Ydumo Ake Ola",
    "cit_Aqe",
    "cit_Ul Gogipizex",
    "cit_Ojikazalo",
    "cit_Equn Qym",
    "cit_Uda Im D Tovuser",
    "cit_Utobi",
    "cit_Eq X Cizeta Ywyqaq",
    "cit_Oduj Co",
    "cit_Ox Gyk",
    "cit_Ucuwolarifevu",
    "cit_Opamacimevuko",
    "cit_Uzemele",
    "cit_I Akugifiwe",
    "cit_Yc Migebumahafez",
    "cit_Afixa",
    "cit_Oqikihega",
    "cit_Ekyhoke Akifypo",
    "cit_Un Gemuj",
    "cit_Yre",
    "cit_Ele Ymame",
    "cit_Ala Ubeki",
    "cit_Ep Feqakim",
    "cit_Y Ores Sy Uw",
    "cit_Asami If Datomos",
    "cit_Ycaxapumekit",
    "cit_Asadiq Qe",
    "cit_U Uhav",
    "cit_Ycog",
    "cit_Axyve",
    "cit_Y Isarexupa",
    "cit_Agyga",
    "cit_Usy Ym Vu Ysyre U",
    "cit_Ojylyd Zanu",
    "cit_Uz Ke",
    "cit_Ynynecira",
    "cit_Icem",
    "cit_Avusoxiwa",
    "cit_Uzymy",
    "cit_I A I",
    "cit_Acowimok",
    "cit_Avimo Ajorim",
    "cit_Uvahag Selyzemele",
    "cit_Ifyran",
    "cit_Ycecorydovozyx Pev",
    "cit_Atogovujyn",
    "cit_U A Ywylowinok",
    "cit_Ujawikaseh Bes",
    "cit_Erawig",
    "cit_Ewaralu Oc",
    "cit_E Ydupecokatuw",
    "cit_Eqa",
    "cit_Il N Rudit",
    "cit_O Ire Ekavidimur D",
    "cit_Aleboku Ab",
    "cit_Oge Abid",
    "cit_Aluz Retera",
    "cit_Exahecehilebo",
    "cit_Y Iqa",
    "cit_Avu I",
    "cit_Init Cipilekasahy",
    "cit_Usy",
    "cit_Ezavaqoxygab T",
    "cit_Akewadudadyk",
    "cit_Yqoqydew Sy Ax Z",
    "cit_Awulu Uhym",
    "cit_Onugakofugedakaqoq",
    "cit_E Yqix Nidoz",
    "cit_Ituwum",
    "cit_Yq Vavifetyz",
    "cit_Ucitedacyza Owe",
    "cit_U Eqetad",
    "cit_Ot Bydytyqu",
    "cit_Yzazeduha Oga",
    "cit_Yhe",
    "cit_Oxyjeralezebi Ug",
    "cit_Eq",
    "cit_Oneh Ferusylicu",
    "cit_Aq Hiqude Um H",
    "cit_Eqeno Ipa Axuso Y",
    "cit_Yxucu Azanonekec",
    "cit_Ytadymyworarap Xi",
    "cit_Ekimotuj",
    "cit_Oto Ofapexajesug",
    "cit_Yhed C",
    "cit_Ilequgip",
    "cit_Ofuraqu",
    "cit_Uge Akari",
    "cit_Uho",
    "cit_Esug",
    "cit_Adopeq",
    "cit_Ejecuryg Vegogiv",
    "cit_E Yrafagew",
    "cit_Yqoq B Mocam Diver",
    "cit_Erenij Liwan",
    "cit_Uk Z Luxyvuty Ysa",
    "cit_Ynu U",
    "cit_E Ipyfinadehe",
    "cit_Ejik Tapiq Gava",
    "cit_Yxotys V",
    "cit_Ubejaqibenokybebet",
    "cit_Eq Helydekityd",
    "cit_Otopakeva",
    "cit_Uxobifakowelem",
    "cit_Eryfo",
    "cit_Ymaga",
    "cit_A Afetehyduby",
    "cit_Asazyn Pu At",
    "cit_Enapitewiwekib",
    "cit_Inuninamut W",
    "cit_Ez V Heruk Cin Vef",
    "cit_Icyjufazaniwe Ufuc",
    "cit_Edecuw Sezapycumej",
    "cit_Udocegu Egokavo",
    "cit_Ad B Nec",
    "cit_Eqabyb",
    "cit_Odezaxoxicig Q Z",
    "cit_Isolosoqoqy Ebec",
    "cit_E Itotu",
    "cit_I Ywib",
    "cit_Alywi Ep",
    "cit_Execa Apezyqav",
    "cit_Urex Mib",
    "cit_Uvub Hutetubyro",
    "cit_Idel",
    "cit_Ik Povuwal",
    "cit_Uxazumada",
    "cit_Evycajimecu Arorad",
    "cit_Ezogaxuzicuga",
    "cit_O Aqakokagy",
    "cit_Em Zusiwyf Ja O",
    "cit_Ipeba Azu Ake",
    "cit_Yf Pajofaxacyx",
    "cit_Y Adopygaconunuw J",
    "cit_Obegybece",
    "cit_Ozebejisak",
    "cit_Ycup Kunysin",
    "cit_Adoq",
    "cit_Obi",
    "cit_A Akoryvyr",
    "cit_Yqymot",
    "cit_Ulacejywufa",
    "cit_Ep Fopunabe O Oc C",
    "cit_Ewywagaje",
    "cit_Aqova E Ega Aron",
    "cit_Ujypykoky",
    "cit_Imo Yralucyluwu",
    "cit_Ifog Ne",
    "cit_Exa",
    "cit_Olyco",
    "cit_Ywocyqubog Gonavaj",
    "cit_Ohepypapez H",
    "cit_Utuqi E Ujake",
    "cit_Ihiwahyk",
    "cit_Iryq Byr",
    "cit_Ofikewum Gak Fe",
    "cit_Adu Esifyvelo",
    "cit_Eqog Moropyw R Wor",
    "cit_Uf Wuhuc",
    "cit_Yvegelugojihykeca",
    "cit_Ek Gafe Uv",
    "cit_Okem Dabac Ra Ara",
    "cit_Ebara Yd Da",
    "cit_Aq Xapysymajupedag",
    "cit_Unohufyx Zazobuwix",
    "cit_Ulufar Jofa O",
    "cit_Umumipexic",
    "cit_Yjyz",
    "cit_Id N Nydywawevi",
    "cit_Ebeneciq P Sik",
    "cit_Ufal Geqazix",
    "cit_Evudunyta Upirig",
    "cit_I Uzadecid Z",
    "cit_Ytu Yso",
    "cit_Idu Ywyva",
    "cit_Uloxih Ku Ebelod",
    "cit_Ecesikut",
    "cit_Iric Ruwu Ag Weky",
    "cit_Upojyg",
    "cit_Ilexohehezyh Tono",
    "cit_Emokakesowycav",
    "cit_Avu Udexeduka",
    "cit_Oki",
    "cit_Y Inohorejebij V",
    "cit_Eca E Awuvypimu",
    "cit_Yt Vimyv Pavih",
    "cit_Idusikafil De Ufaw",
    "cit_Ofof",
    "cit_Isom Lare",
    "cit_Yjisykuvyfupig",
    "cit_Ac Degydypaj Guc",
    "cit_Omoromew Gilolo",
    "cit_Emevaqutolohoqomec",
    "cit_Eqodaco Em",
    "cit_Apogivod K",
    "cit_Esy Y Ali",
    "cit_Ox Zumeki Ovikiz",
    "cit_Uhe",
    "cit_Efa",
    "cit_O Irej Nag F",
    "cit_Avixit",
    "cit_Osasutoci Op",
    "cit_Ymawit",
    "cit_Yze Az Ko U Al",
    "cit_Edibyn Jydu",
    "cit_Ydihyna",
    "cit_Imuvypebipobemome",
    "cit_Ilepicarogeger Cys",
    "cit_Ixu",
    "cit_Ohu",
    "cit_Yloqyba Oces Bej",
    "cit_Adilyq",
    "cit_A Igi",
    "cit_Ifa",
    "cit_Iwotaza Ukeqasah",
    "cit_Imozen",
    "cit_Akajira",
    "cit_Ilosinu",
    "cit_Alejisuzynahyne",
    "cit_Yjewafigic Se Ab T",
    "cit_Ynyvemu",
    "cit_Azadig",
    "cit_Api Aro Awusybeh",
    "cit_Uxeduzomig",
    "cit_Elenadugun",
    "cit_Okamyf Wyr",
    "cit_A Ety Imucaj",
    "cit_Ewa",
    "cit_Ozure",
    "cit_Ereta I Anypybe Yb",
    "cit_Ekitarazuka",
    "cit_O Ibakerax Bu",
    "cit_Afiradexydosu O",
    "cit_Umevoh Sop Ki",
    "cit_Asuxipesyriw Kug",
    "cit_Adutij",
    "cit_Uwesoramyvaz Gugi",
    "cit_Ypijoryp",
    "cit_Ynadawexedoju",
    "cit_Op Z Nuxesuwo",
    "cit_Ygurigasaveze",
    "cit_Atytaxatudehy",
    "cit_Aqukuvamihy",
    "cit_Ih S",
    "cit_Igym J",
    "cit_Ajinewa",
    "cit_Itovyjofe",
    "cit_O U Ud",
    "cit_Azymytu",
    "cit_Iqibo E Erepytyby",
    "cit_Ufip Jemezul",
    "cit_Edadezedyzycehepe",
    "cit_Iquge",
    "cit_Eja",
    "cit_Ize Uvet N Cavuvif",
    "cit_Ezocuceme Avikanav",
    "cit_O Ytajare Uwo",
    "cit_Ire Obypik",
    "cit_Ugufukelajegep",
    "cit_Izokaqav Dyh",
    "cit_Evy Obimunixyz Ly",
    "cit_Uquma Er",
    "cit_Aboxozoj",
    "cit_Adi",
    "cit_Ysyhyqafa",
    "cit_Itemipilipu U",
    "cit_O Ybu Ub",
    "cit_Ic Mu Iba Ifeced",
    "cit_Uvu E Ic",
    "cit_Ig Xejuf",
    "cit_Yziwabef Ceta O",
    "cit_Ileq",
    "cit_E Ojix",
    "cit_Ujet",
    "cit_Y Uketelole",
    "cit_Yxemifidyrod",
    "cit_Etagivyloda I",
    "cit_Ilevovyb Coqa",
    "cit_Yramevu",
    "cit_Irykihezo",
    "cit_Ij F",
    "cit_Ibifilifasez Q",
    "cit_Oxu Inuj",
    "cit_Oxix",
    "cit_Ir Bacyv Wijumire",
    "cit_Ypofekaq Syrugew",
    "cit_Ud Kucexo",
    "cit_A Ode Udipoxyd",
    "cit_Enikocimot",
    "cit_Us K",
    "cit_O Awabob",
    "cit_Okygolato",
    "cit_Aniqaqu Ypeg",
    "cit_Ape Ipapacikipi",
    "cit_Ajiny Ad Hyjicax",
    "cit_Iko Evyqis",
    "cit_Aruvel",
    "cit_Omozy",
    "cit_I Ahalahec G",
    "cit_Obyxogynukedi",
    "cit_Idul Vi",
    "cit_Ojopoda",
    "cit_O Y Y",
    "cit_Edu Anev Dywaranu",
    "cit_Okehepubuxa Orisyc",
    "cit_Otetufuzy O Et",
    "cit_Aqu E Obunip",
    "cit_Ywu Asy Ono I",
    "cit_Ixyty Umatizuv",
    "cit_Yladamok",
    "cit_I Yfuqahil Hehela",
    "cit_Azohip",
    "cit_Awe",
    "cit_U E Ona",
    "cit_A Ubevu A",
    "cit_Ep Dek",
    "cit_Ypehyj",
    "cit_Ez Hot Wu A",
    "cit_Ygyba Ydasizezy",
    "cit_Ulup Mitu",
    "cit_Oq Vexyc",
    "cit_I Umo Icapotut G",
    "cit_Opuhaqi U",
    "cit_Ykejo",
    "cit_Ixuka O Owaqasirov",
    "cit_Ec Daris Pefykoce",
    "cit_Yxyz",
    "cit_Oq Hyd",
    "cit_Y Ijer Hove",
    "cit_Ofef",
    "cit_Edezanapyraga Ehu",
    "cit_Az Pymucybinuvifyn",
    "cit_Isiz Pakumyzaqewi",
    "cit_Ikakelyzohaxih",
    "cit_Yc Nehy Ypag",
    "cit_Ini Asesy It",
    "cit_Eduborotazew My",
    "cit_Idunoke",
    "cit_Ux Tat",
    "cit_Ytu",
    "cit_Ezike",
    "cit_Izominumub",
    "cit_Efajavas Re",
    "cit_Ax Ko Ahavy Ysihu",
    "cit_Edoxoqa Uquz",
    "cit_Efapop Fuvezy",
    "cit_Usoreku",
    "cit_Owebew",
    "cit_Aj C Xumevecaha",
    "cit_Onu Ubofapeqix",
    "cit_Evy Exuridehezequ",
    "cit_Ixuly Efa",
    "cit_Ixywufeby",
    "cit_Yh W",
    "cit_Un Wa",
    "cit_Atipep V My",
    "cit_Axaxuz",
    "cit_Ilo Ymotexobudymy",
    "cit_Ory Ociryzi I U",
    "cit_E Ic Qesyd",
    "cit_Aju Ih Su O Ibave",
    "cit_Aceca",
    "cit_E Yzebe Y",
    "cit_Yc C",
    "cit_U Yhe Oxower",
    "cit_Anuxotuj",
    "cit_Uva",
    "cit_Ininu Y Asutijyhyz",
    "cit_Ubob",
    "cit_Une",
    "cit_Aqoziwe",
    "cit_Erum",
    "cit_Yf Li",
    "cit_Ikepyjerybitepucu",
    "cit_Iwosohoxavenaluwu",
    "cit_Uxexyjebuby",
    "cit_Om Cy Ezycerinecy",
    "cit_Ove Enofez P",
    "cit_Yhuryfikerer",
    "cit_Ykasete",
    "cit_Ugyjafa U Otudivez",
    "cit_A Ot Mewicizef",
    "cit_Og Febypy",
    "cit_Etule",
    "cit_Ezelex",
    "cit_Ojulota I",
    "cit_U Ejabibece",
    "cit_Ajuleq",
    "cit_Awypag K",
    "cit_Apyzoja",
    "cit_U Amujyzeti Yvo",
    "cit_I Inejyw",
    "cit_O I Ipifogi Idimu",
    "cit_Yquxina Oho Ikozav",
    "cit_Itozefazej",
    "cit_I Odyt Goh",
    "cit_On Fileruzul Deg",
    "cit_Alocutel Defule",
    "cit_Ar Zovakikyn",
    "cit_Edex Kot",
    "cit_Oxevoxalal",
    "cit_Awamopazy I Eqabab",
    "cit_Yzebedag",
    "cit_Ucyh Fyxe",
    "cit_Ynac G Qeto Ober W",
    "cit_Apohuluqarazebe",
    "cit_Uwaha",
    "cit_Uwazy",
    "cit_Uzi Iv",
    "cit_Utu Efexirecesyr",
    "cit_Ihejuri Acas X Wob",
    "cit_Igaf Xydijidib",
    "cit_Al Lypypon",
    "cit_I Ypoqo Ilal",
    "cit_Ijatamowezu E",
    "cit_Yholawig Bym V Rez",
    "cit_Aqawacuqy",
    "cit_Ymyxofuhehiwa",
    "cit_Er Rage Abexajopaz",
    "cit_Ofydydy",
    "cit_A Otavubujom",
    "cit_Y Ojun",
    "cit_Ah Cexa",
    "cit_Yqa",
    "cit_Otade",
    "cit_Akiqafe Uh B Joke",
    "cit_Yxicekid Xuqeb",
    "cit_Omyqyjos",
    "cit_Edogekaqeh",
    "cit_Ezipukiqutu Awek",
    "cit_Eh Pewydoref",
    "cit_Alezaxa",
    "cit_Yv Po Udesa Ux Wop",
    "cit_A Exegefa",
    "cit_Ovuxe Ufypyp",
    "cit_Yh Ko Ur",
    "cit_Og Dosa Odigo",
    "cit_Aq Xahi",
    "cit_Ofi Ipe",
    "cit_Ezuxapojux",
    "cit_Ebyzo Um C",
    "cit_Asiwavupas Vajy",
    "cit_Iporuryzof",
    "cit_Erafekid",
    "cit_Azovac",
    "cit_It Qiqupa",
    "cit_Obefuvosyvu E",
    "cit_Yfin G",
    "cit_Uqi",
    "cit_Y O Ilegah",
    "cit_Upemo Yrazix Mot",
    "cit_Osev Kulawi",
    "cit_Ymi O Ile Etixag",
    "cit_Ez Jyfacigyk",
    "cit_Ebowy Udoq",
    "cit_Apinecykebadupuv",
    "cit_Ilezypyvifileqiguc",
    "cit_Exymivireza",
    "cit_Yxonyqiveg Henuro",
    "cit_Yhowe",
    "cit_Amara Uz Sikin",
    "cit_Iro",
    "cit_Eqoky A U",
    "cit_Uwapoceqetyh",
    "cit_U Iteqaf P",
    "cit_Oqicefu",
    "cit_Y Umacequzub",
    "cit_I Amese A Yretu",
    "cit_Akoto",
    "cit_Ola",
    "cit_Acelopu Et",
    "cit_Ekobop Z",
    "cit_Y Ominucana Om",
    "cit_Imuqo",
    "cit_Yt Da Ekeken",
    "cit_Ajed",
    "cit_Ekuhyri Oraxa",
    "cit_Obyfusetujasic Zop",
    "cit_Esec Hetizeb",
    "cit_Un Qojasohibeho",
    "cit_Ysune Ehiqyfi",
    "cit_Ybamisis Naj",
    "cit_Ytevi Ul",
    "cit_Ajaceqavybex",
    "cit_Ikylyduzi",
    "cit_U Emigycawawo",
    "cit_Uvysyzavi Oqy Y",
    "cit_Uqebup",
    "cit_Edazuqas",
    "cit_Alobe Arogoquge",
    "cit_A Esetenoco",
    "cit_Eky Ipiqot Zepy",
    "cit_Ysuha",
    "cit_Urajexone",
    "cit_E Os",
    "cit_Esysow Ger C",
    "cit_Ejabymeli",
    "cit_Ilufih",
    "cit_Umeby I E",
    "cit_Etixe",
    "cit_O As Xinudyjycig",
    "cit_E Owymijupeq T Vi",
    "cit_Amyjemo Oqusazoqe",
    "cit_Uw Mazapov Ku Uwan",
    "cit_O Iwejeq",
    "cit_Okub C Qoku",
    "cit_Ejalax",
    "cit_Ep Qom Cebym",
    "cit_Y Ynewuz Laxi",
    "cit_Uny",
    "cit_Yruna",
    "cit_Yhuq",
    "cit_Awidejosose Ofamaf",
    "cit_Yguf",
    "cit_Iso Ogapacozyhupym",
    "cit_Ulitacabad Tora",
    "cit_Udequnyk X Dux",
    "cit_Aguqe Y",
    "cit_Uwe Uto",
    "cit_Ebyhon Qase Osex",
    "cit_Yhyd Do",
    "cit_Usexydime",
    "cit_Obozoz",
    "cit_Axaz",
    "cit_Avew",
    "cit_Y Yfeted",
    "cit_Ecyk",
    "cit_Erabesuco Ipad",
    "cit_Elizejyroces",
    "cit_Ajalyh H",
    "cit_Es Lu Yg",
    "cit_Ubewyrukofyvaken",
    "cit_Y Epafuf",
    "cit_Epoqihaj Ga Adi",
    "cit_Eredywy Arux",
    "cit_Ewywasuradeti",
    "cit_Owasitakiwowu",
    "cit_Unyqymirom",
    "cit_Owirypecic",
    "cit_Owefa Ytori",
    "cit_O Ugowuxoqa",
    "cit_Uvyhopudiquri",
    "cit_I Egy",
    "cit_Oraful",
    "cit_Ef P",
    "cit_Ohimopamibex",
    "cit_Yg Sydedubabu U Ov",
    "cit_Yde",
    "cit_Yxu Edeva O Ede",
    "cit_Ixaqujifa",
    "cit_Ozaze",
    "cit_Erux Modakipahese",
    "cit_Ovykokanemyvoj J",
    "cit_Ifoke",
    "cit_Ypib Taje",
    "cit_Ilyqyxiv Fimyqysy",
    "cit_Yx K",
    "cit_Oge Yweza Iw Fi E",
    "cit_Yka Enaxewe",
    "cit_Ixuzoze Ohezagibi",
    "cit_Exeleqeban Bic R",
    "cit_O Ybilecalaqazoma",
    "cit_Aka Yfizogozagu",
    "cit_Ifa I Opylysu",
    "cit_Iwab Vyqu Eh Pi",
    "cit_Asufocy Oku",
    "cit_Ihujeqa",
    "cit_Ibeqoquz Bas Caw Z",
    "cit_Uwyjopyzaje Uro",
    "cit_Yp Lubav Nane O",
    "cit_Exe",
    "cit_Uvegawajydu",
    "cit_Odyluras Tezi",
    "cit_Exibavoquf",
    "cit_Iquhu",
    "cit_Akyh",
    "cit_Yz Tiza",
    "cit_Upi Efyg",
    "cit_Yrebupe",
    "cit_Ive E Ilymebigumu",
    "cit_Emik",
    "cit_Edas Pabun",
    "cit_Ejim",
    "cit_Ekab Fybikebavi",
    "cit_Eles Vu",
    "cit_Uregakego Uca",
    "cit_Upyke Esiq Vazyh",
    "cit_Eluxob",
    "cit_Amuhunep",
    "cit_Itulepacoferuny",
    "cit_Ajyn",
    "cit_Ykuqukatobisike",
    "cit_Ix P",
    "cit_Ytopobexekivopekab",
    "cit_Elowa Ano",
    "cit_Ozehuloresy O",
    "cit_E Upone E Yce Ow Q",
    "cit_Upozus",
    "cit_Aqehu",
    "cit_Ih Zas Matyf"
};

var t1 = Task.Run(() =>
    Parallel.For(0, 100000, new ParallelOptions { MaxDegreeOfParallelism = 100 }, i => {
        var random = new Random();
        for (int j = 0; j < 1000; j++)
        {
            try
            {
                var city = cities.ElementAt(random.Next(0, 999));
                var request = (HttpWebRequest)WebRequest.Create($"http://localhost:5120/city/locations?city={city}");
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                Enque();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    })
);
var t2 = Task.Run(() =>
    Parallel.For(0, 100000, new ParallelOptions { MaxDegreeOfParallelism = 100 }, i =>
    {
        var random = new Random();

        for (int j = 0; j < 1000; j++)
        {
            try
            {
                var ip = $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
                var request = (HttpWebRequest)WebRequest.Create($"http://localhost:5120/ip/location?ip={ip}");
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                Enque();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }));

Task.WaitAll(t1, t2);
cts.Cancel();