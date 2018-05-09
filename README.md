# Popis brancheva

**Napomena:** Sav kod se nalazi raspoređen po branchevima;

| **Naziv applikacije (link na branch)** | *Opis*          |
| ------------- |-------------|
| [**OCRApplication**](https://github.com/ivanorsolic/VolunteeringToday/tree/OCRApplication) | [*CognitiveServices Vision API*](https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/) - machine-learning potpomognut app koji analizira slike te izvlači tekst i riječi iz istog (rukopis, bilo kakav font). |
| [**FaceRecognitionApplication**](https://github.com/ivanorsolic/VolunteeringToday/tree/FaceRecognitionApplication) | [*CognitiveServices Face API*](https://azure.microsoft.com/en-us/services/cognitive-services/face/) - machine-learning potpomognut app koji na temelju zadanih slika uči raspoznavati lica pojedinaca, te može raspoznavati do 64 osobe na istoj slici, do 10 000 osoba ukupno. |
| [**TwitterAnalytics**](https://github.com/ivanorsolic/VolunteeringToday/tree/TwitterScripts) | Skripta koja za odabrani Tweet dohvaća podatke potrebne za izradu analitike. Koristi [*TwitterApi*](https://developer.twitter.com/en/docs) i popratne [*Python biblioteke*] (https://developer.twitter.com/en/docs/developer-utilities/twitter-libraries). |
| [**TwitterScraper**](https://github.com/ivanorsolic/VolunteeringToday/tree/TwitterScripts) | Skripta koja pretražuje Twitter za objave vezane uz volontiranje, kako bi se među njima mogli identificirati potencijalni događaji i akcije. Koristi [*TwitterApi*](https://developer.twitter.com/en/docs) i popratne [*Python biblioteke*] (https://developer.twitter.com/en/docs/developer-utilities/twitter-libraries). |
| [**TwitterBot**](https://github.com/ivanorsolic/VolunteeringToday/tree/TwitterScripts) | Bot koji obavještava Twitter korisnika da je njegov događaj automatski unešen na naš web, pomoću Tweeta i DM-a. |
| [**JSONParser**](https://github.com/ivanorsolic/VolunteeringToday/tree/TwitterScripts) | Pomoćna skripta koja iz CognitiveServices JSON odgovora izvlači human-readable tekst koji se koristi u daljnoj obradi. |

# Opis projekta

- Ideja projekta je automatizirati popunjavanje te kategoriziranje svih volonterskih događaja podijeljenih na društevnim mrežama.
Kao PoC, aplikacija se spaja na Twitter koristeći [**TwitterAnalytics**](https://github.com/ivanorsolic/VolunteeringToday/tree/TwitterScripts/), pretražujuću relevantne hashtagove (PoC example: ***`"#VolunteeringTodayKingICT"`***).

- Nakon spajanja na Twitter, pokreće se [**TwitterScraper**](https://devking.king-ict.hr/gitlab/changecode/SirotiljaValley/blob/TwitterScripts/TwitterScraper.py) koji dohvaća sve Tweetove sa zadanim hashtagom, te downloada prateće slike.

- Slike se zatim obrađuju koristeći [**CognitiveServices vision i OCR**](https://github.com/ivanorsolic/VolunteeringToday/tree/OCRApplication/OCRApplication/OCRTools.cs).

- CognitiveServices vraća odgovor u obliku JSONa, koji se parsira koristeći [**JSONParser**](https://github.com/ivanorsolic/VolunteeringToday/tree/TwitterScripts/json_to_text.py) te se pretvara u human-readable tekst iz kojega se ekstrahiraju najbitniji podaci, poput: e-maila, datuma, lokacije i sl.

- Odgovor se šalje na [**backend API**](https://github.com/ivanorsolic/VolunteeringToday/tree/master) koji automatski popunjava [**Web**](https://github.com/ivanorsolic/VolunteeringToday/tree/master) sa novim događajem, te aktivira [**TwitterBota**](https://github.com/ivanorsolic/VolunteeringToday/tree/TwitterScripts/PostTweets.py) koji obavještava korisnika o mogućnosti moderiranja svog događaja na stranici.

- Web se zatim periodično (svakih par minuta) popunjava novonastalnim događajima na Twitteru koji su prepoznati kao volonterski događaju, koristeći ranije spomenuti proces.

- Organizatori čiji su događaji automatski uneseni se mogu ulogirati pomoću svog Twitter računa te uređivati svoj događaj te uploadati slike događaja radi evidentiranja prisutnosti volontera.

- Volonteri se mogu ulogirati pomoću svog Twitter računa, te prilikom registracije dodaju svoju sliku lica, pomoću koje AI uči prepoznavati volontera u slikama događaja na kojima se volonter nalazio, te mu u bazi evidentira sudjelovanje.

# Upute za testiranje

1. **Dodati sliku nekog plakata** za volonterski događaj pomoću svog ili našeg testnog Twitter accounta, **koristeći hashtag** `#VolunteeringTodayKingICT`
	- Username: `@VolunteerTheBot`
	- Password: `Ori123`
	- Test image: [link na imgur](https://i.imgur.com/3v50RwX.jpg)
	- Hashtag (bitno): `#VolunteeringTodayKingICT`
	- Note: very secure pwd sharing
	- Importanter note: Skripti treba cca 1 min da dohvati novi post sa Twittera, please be patient. Thanks.
2. **Ulogirati/Registrirati se sa istim userom** (koji je postavio sliku) na Web: http://volunteering.today
3. **Postaviti sliku svog lica prilikom registracije**
    - Test fotka: ["Dwayne the Rock Johnson"](https://upload.wikimedia.org/wikipedia/commons/f/f1/Dwayne_Johnson_2%2C_2013.jpg)
4. **Pronaći svoj događaj na Webu**
5. **Dodati sliku događaja** sa nekom drugom slikom svog lica
    - Test fotka događaja: ["The sole volunteer Dwayne the Rock Johnson"](https://ia.media-imdb.com/images/M/MV5BMTkyNDQ3NzAxM15BMl5BanBnXkFtZTgwODIwMTQ0NTE@._V1_UX214_CR0,0,214,317_AL_.jpg)
6. **Provjeriti popis volontera**
    - There's you or Dwayne the Rock Johnson
7. **Provjeriti profil** [**VolunteerTheBot-a**](https://twitter.com/volunteerthebot) kako bi vidjeli obavijest korisniku da je njegova slika korištena (moguće i prije registracije)

## Thank you for your time

![Our lord and saviour in difficult debugging times, the rubber duck](https://media1.giphy.com/media/u6abG1EmZciv6/200.gif)


