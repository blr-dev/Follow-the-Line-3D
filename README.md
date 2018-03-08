Podstawy pracy z dźwiękiem – Plan Projektu


Dokumentacja projektu zaliczeniowego

a) Projekt Unity posiada tylko dwa miksery, jeden poboczny zawiera tylko dzwięk w tle (toczącej się kuli po planszy) natomiast drugi - główny, pozostałe efekty dzwiękowe. Nie było potrzeby komplikowania tego ponieważ gra nie jest tak skomplikowana oraz nie posiada nawet animacji, które można udzwiękowić. Zastosowane dzwięki pochodzą z Assets Store z różnych projektów. Kilka z nich zostało delikatnie zmienione w programie Reaper i Audacity. 

b) Osiągnąłem cały cel zadanego mi udzwiękowienia projektu. Gra nie jest tak pusta po uruchomieniu. Oprócz "sztywnego" dodania dzwięku podnoszenia gema poprzez wykrycie GameObjectu zrobiłem też metodę AudioPlay jako singleton działający na cały projekt i to on uruchamia dzwięki. Chociaż dzwięki nie są w żaden sposób profesjonalne ani pasujące, to bardziej wypełniają całość tego projektu gry. Nie zrobiłem menu gry oraz menu pauzy więc tylko to bym jeszcze dodał jeśli chodzi o dzwięk.


Lista efektów dźwiękowych:
⦁	Spawn gracza;
⦁	Wypadnięcie z planszy;
⦁	Zmiana koloru platform po osiągnięciu pewnej ilości punktów;
⦁	Zmiana kierunku poruszania gracza;
⦁	Podniesienie "gema";
⦁	Tło - tocząca się kula po planszy;

Struktura mikserów i grup:
⦁	Mikser muzyki – dźwięk w tle;
⦁	Mikser efektów dźwiękowych;

Komponenty AudioSource:
⦁	AudioSource tła;
⦁	AudioSource podnoszenia "gemów";
⦁	AudioSource innych efektów dźwiękowych;
