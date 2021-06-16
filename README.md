# Dungeon Master
#### This game can be built from its own release or its launcher's release. The game launcher is available [right here!](https://github.com/bUsernameIsUnavailable/MDS-WPFLauncher)
  
 # Team members :
 <ul>
  <li>Kaya Adrian</li>
  <li>Gherasim Rares</li>
  <li>Popa-Podarasu Ioan-Petrino </li>
 </ul>

# User stories : 
![image](https://user-images.githubusercontent.com/61795553/122225380-b114c000-cebd-11eb-9ab2-6f5be3152ec7.png)

# Descrierea jocului :
În momentul de față, un jucător poate să descarce launcherul și să înceapă un nou joc. De fiecare dată când jocul este rulat, o hartă nouă și diferită se generează cu un număr de 20 de inamici pe aceasta si cu mai multe camere. Jucătorul trebuie să treacă prin toate camerele fără a-și pierde viața din cauza atacurilor inamicilor. Inamicii vor încerca să îl atace venind foarte aproape de acesta. Pentru a se apăra, dar și pentru a-și omorî adversarii, playerul poate să atace folosindu-se de sabia pe care o are în mână, care omoră inamicii din 3 lovituri. Pentru movement se pot folosi ori tastele WASD ori săgețile de pe tastatură.
![image](https://user-images.githubusercontent.com/61795553/122228066-2bdeda80-cec0-11eb-90d4-780a005c4da3.png)


# Instalare :
Pentru a instala proiectul este suficient sa avem Launcherul prezent in primul paragraf. Practic acesta este legat de un google drive pe care se afla starea curenta a jocului si numarul versiunii. Daca versiunea din launcher difera de cea de pe drive, atunci descarca si incarca noua versiune. Daca nu, nu face nimic.
![image](https://user-images.githubusercontent.com/61795553/122226296-8414dd00-cebe-11eb-9126-cec1d8a99258.png)


# UML : 
Acesta este realizat doar pentru generatorul hartii, care este unul aleator iar la ficeare rulare genereaza harta altfel. Schema UML este urmatoarea (MonoBehaviour este o parte implementată deja în Unity, restul sunt implementate de noi):
![DungeonClasses](https://user-images.githubusercontent.com/61795553/122226859-06050600-cebf-11eb-99d2-4e347898a74f.png)

# Source control :
Pentru partea de branch-uri am lucrat pe un singur branch, pe cel denumit master. Am avut 52 de commit-uri pe parcursul proiectului, deoarece am incercat să menține evindența fiecărei mici schimbări pe care am adus-o codului sau aspectului jocului.

![image](https://user-images.githubusercontent.com/61795553/122229137-2930b500-cec1-11eb-8678-3b5b321d137f.png)

# Teste automate :

![image](https://user-images.githubusercontent.com/61795553/122232905-4915a800-cec4-11eb-9243-6778a9057bd1.png)


# Bug reporting :
Pe partea de bug reporting avem doua buguri raportate în cadrul tabului Issues din proiectul de pe GitHub. Acestea au fost rezolvate, deci sunt marcate drept closed la momentul actual.
![image](https://user-images.githubusercontent.com/61795553/122230145-0bb01b00-cec2-11eb-8fe4-b1fbc6cb007c.png)

# Folosirea unui build tool :
Pentru build tool am folosit singurul build tool pe care am reusit sa il gasim care să funcționeze cu github-ul și cu unity, acesta realizând versiuni are jocului pentru următoarele platforme: MacOS, Windows x32, Windows x64, Linu x64. Am reușit să testăm pe MacOS și pe Windows x64 și putem spune că merge foarte bine pe acestea. La fiecare push care se realizează, buildtool-ul acționează și generează variantele necesare ale proiectului.

![image](https://user-images.githubusercontent.com/61795553/122230783-9e50ba00-cec2-11eb-8bc1-b40b292c97c9.png)

# Design patterns :
Pentru a putea implementa partea de Design Patterns am folosit un Singletone generic care este mostenit de clasa GameManager a noastră. Această clasă are rolul de a administra funcționalitățile jocului și de a-l genera, motiv pentru care un Singletone este optim pentru aceasta deoarece nu ne dorim niciodată să apară două obiecte instanțiate cu această clasă în cadrul jocului.
![image](https://user-images.githubusercontent.com/61795553/122232073-a2c9a280-cec3-11eb-9ce2-617945b0b511.png)

![image](https://user-images.githubusercontent.com/61795553/122232136-af4dfb00-cec3-11eb-87d3-dcc950ced08e.png)


 <br/>
 
 # External sources
 ### [Dungeon sprites](https://pixel-poem.itch.io/dungeon-assetpuck) by [Pixel_Poem](https://pixel-poem.itch.io/)
 
 ### [Character and item sprites](https://0x72.itch.io/dungeontileset-ii) by [0x72](https://0x72.itch.io/)
