# Dungeon Master
#### This game can be built from its own release or its launcher's release. The game launcher is available [right here!](https://github.com/bUsernameIsUnavailable/MDS-WPFLauncher)

# Demo 
Un demo scurt al proiectului poate fi regasit la adresa: https://www.youtube.com/playlist?list=PLULUoHU4FGAXcJky7CBuof_mTgM9BCVC2 .
  
 # Membrii echipei
 <ul>
  <li>Kaya Adrian</li>
  <li>Gherasim Rareș</li>
  <li>Popa-Podărăscu Ioan-Petrino </li>
 </ul>

# User stories
![image](https://user-images.githubusercontent.com/61795553/122225380-b114c000-cebd-11eb-9ab2-6f5be3152ec7.png)


# Descrierea jocului
În momentul de față, un jucător poate să descarce launcher-ul și să înceapă un nou joc. De fiecare dată când jocul este rulat, o hartă nouă și diferită se generează cu un număr de 20 de inamici pe aceasta și cu mai multe camere. Jucătorul trebuie să treacă prin toate camerele fără a-și pierde viața din cauza atacurilor inamicilor. Inamicii vor încerca să îl atace venind foarte aproape de acesta. Pentru a se apăra, dar și pentru a-și omorî adversarii, player-ul poate să atace folosindu-se de sabia pe care o are în mână, care omoră inamicii. Pentru movement se pot folosi ori tastele WASD, ori săgețile de pe tastatură.

![image](https://user-images.githubusercontent.com/61795553/122228066-2bdeda80-cec0-11eb-90d4-780a005c4da3.png)


# Instalare
Pentru a instala proiectul este suficient să avem launcher-ul prezent în primul paragraf. Practic acesta este legat de un Google Drive pe care se află starea curentă a jocului și numărul versiunii. Dacă versiunea din launcher diferă de cea de pe Drive, atunci descarcă și încarcă noua versiune. Dacă nu, nu face nimic.

![image](https://user-images.githubusercontent.com/61795553/122226296-8414dd00-cebe-11eb-9126-cec1d8a99258.png)


# UML
Acesta este realizat doar pentru generatorul hărții, care este unul aleator, iar la fieceare rulare generează harta altfel. Schema UML este urmatoarea (MonoBehaviour este o parte implementată deja în Unity, restul sunt implementate de noi):

![image](https://user-images.githubusercontent.com/61911973/122295406-d1ff0480-cf01-11eb-884e-b1cb6f117590.png)


# Source control
Pentru partea de branch-uri am lucrat pe un singur branch, pe cel denumit master. Am avut 52 de commit-uri pe parcursul proiectului, deoarece am incercat să menținem evindența fiecărei mici schimbări pe care am adus-o codului sau aspectului jocului.

![image](https://user-images.githubusercontent.com/61795553/122229137-2930b500-cec1-11eb-8678-3b5b321d137f.png)


# Teste automate
Unity suportă două tipuri de teste automate: cele din Edit Mode și cele din Play Mode. Ele pot fi văzute în Unity mergând la Window > Panels > Test Runner.

![image](https://user-images.githubusercontent.com/61911973/122295261-aaa83780-cf01-11eb-8d3d-8b2f591c908c.png)

Testele în modul Edit sunt menite să testeze părți din cod în orice moment, făcându-le foarte similare cu testele automate regăsite în alte tipuri de software. Pentru acest tip testăm dacă cele 4 direcții cardinale și diagonalele, folosite pentru algoritmul Simple Random Walk în generarea aleatoare, au coordonatele potrivite ca să ne asigurăm că fiecare direcție corespunde cu realitatea.

![image](https://user-images.githubusercontent.com/61911973/122295088-6f0d6d80-cf01-11eb-9b52-8e8586d05593.png)

Însă, testele din modul Play vor porni o instanță a jocului deoarece sunt menite să testeze comportamentul codului la runtime. Pentru acest mod am testat dacă există tile-uri pentru podea care să fie izolate, adică dacă există părți inaccesibile pe hartă, lucru ce nu ar trebui să se întâmple niciodată.

![image](https://user-images.githubusercontent.com/61911973/122295137-83ea0100-cf01-11eb-853a-f7c5d3314c9a.png)


# Bug reporting
Pe partea de bug reporting avem două bug-uri raportate în cadrul tabului Issues din proiectul de pe GitHub. Acestea au fost rezolvate, deci sunt marcate drept closed la momentul actual.

![image](https://user-images.githubusercontent.com/61795553/122230145-0bb01b00-cec2-11eb-8fe4-b1fbc6cb007c.png)


# Build tool
Pentru build tool am folosit singurul build tool pe care am reușit să îl găsim care să funcționeze cu Unity, acesta realizând versiuni are jocului pentru următoarele platforme: MacOS, Windows x32, Windows x64, Linux x64. Am reușit să testăm pe MacOS și pe Windows x64 și putem spune că merge foarte bine pe acestea. La fiecare push care se realizează, build tool-ul acționează și generează variantele necesare ale proiectului.

![image](https://user-images.githubusercontent.com/61795553/122230783-9e50ba00-cec2-11eb-8bc1-b40b292c97c9.png)


# Design patterns
Pentru a putea implementa partea de design patterns am folosit un singleton generic care este moștenit de clasa GameManager a noastră. Această clasă are rolul de a administra funcționalitățile jocului și de a-l genera, motiv pentru care un singleton este optim pentru aceasta deoarece nu ne dorim niciodată să apară două obiecte instanțiate cu această clasă în cadrul jocului. De asemenea GameManager trebuie să persiste în cazul în care se încarcă o scenă nouă ca să păstrăm datele între ele. Nu am putut implementa mai multe scene, dar dacă era cazul atunci nu ar fi fost o problemă datorită singletonului.

![image](https://user-images.githubusercontent.com/61795553/122232073-a2c9a280-cec3-11eb-9ce2-617945b0b511.png)

![image](https://user-images.githubusercontent.com/61795553/122232136-af4dfb00-cec3-11eb-87d3-dcc950ced08e.png)


 <br/>
 
 # Surse externe
 ### [Sprite-uri pentru camere](https://pixel-poem.itch.io/dungeon-assetpuck) de [Pixel_Poem](https://pixel-poem.itch.io/)
 
 ### [Sprite-uri pentru personaje și arme](https://0x72.itch.io/dungeontileset-ii) de [0x72](https://0x72.itch.io/)
