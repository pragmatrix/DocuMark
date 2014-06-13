\\\ Referenz


Inhaltsverzeichnis COP!

Einleitung

1	Oberfl�che  
1.1	Laufwerksauswahl  
1.2	Anzeigebereich  
1.3	Statusanzeige

1.4	Buffer  
1.4.1	Speicher  
1.4.2	Laufwerk  
1.4.3	Datei  
1.4.4	Bufferinfo

1.5	Spurbereich

2	Optionen

3	Inhalt

4	Aktionskn�pfe

4.1	Lesen  
4.2	Schreiben  
4.3	Kopieren  
4.4	�berpr�fen  
4.5	Formatieren

Anhang A	Tastaturk�rzel  
Anhang B	Fehlermeldungen beim Datenzugriff \\\ ****((((siehe TOP!)))****

# Einleitung 

Da auf Datentr�ger wie Disketten oder manchen Festplatten Fehler auftreten k�nnen, sollten von wichtigen Programmen Sicherheitskopien angefertigt werden. COP! bietet nun diese M�glichkeit mit einigen interessanten Zusatzfunktionen, wie die �berpr�fung und Formatierung von Datentr�gern, sowie das Archivieren von Disketten mit Hilfe eines *externen Komprimierers*.




# 1 Oberfl�che 

Wie gewohnt wird COP! durch einen Doppelklick auf dessen Icon gestartet. Kurz darauf sollte die Oberfl�che erscheinen, die in drei vertikale Bereiche aufgeteilt ist.

Im oberen Bereich befindet sich links die Laufwerksauswahl (`Quelle`, `Ziel(e)` und rechts der Listenanzeigebereich, wo zuerst die schon bearbeiteten Datentr�ger aufgelistet werden, und rechts daneben die Fehler im letzten Bearbeitungsvorgang.

Darunter befindet sich ein kleinerer Bereich, der den *aktuellen Status* anzeigt (momentan steht hier "warte..."), sowie eine *F�llstandsanzeige* mit Prozentangabe, die das Fortschreiten eines *Bearbeitungsvorganges* anzeigt. An der F�llstandsanzeige befindet sich noch der `Stop!`-knopf, der das Unterbrechen jedes Bearbeitungsvorganges erlaubt. Rechts daneben wird noch die aktuelle Spur sowie die seit dem Start verstrichene Zeit in Stunden, Minuten und Sekunden angezeigt.

Im untersten Bereich des Fensters sind die Buffer-Einstellungen, sowie die Spureinstellungen und Aktionskn�pfe plaziert.




## 1.1 Laufwerksauswahl 

Links oben im Fenster von COP! befinden sich zwei Listenanzeigen, in denen Ihre angemeldeten Laufwerke dargestellt werden sollen.

In der Listenanzeige, die mit `Quelle` bezeichnet ist, wird das Quellaufwerk angew�hlt. Von diesem Laufwerk k�nnen also nur Daten gelesen werden. Wird hier ein Laufwerk angew�hlt, das nicht der physikalischen Gr��en eines Ziellaufwerkes entspricht oder schon als Ziellaufwerk angegeben wurde, wird das Laufwerk in der Ziel-Listenanzeige deaktiviert.

Rechts daneben befindet sich die Laufwerksauswahl f�r das oder die Ziellaufwerke. Hier k�nnen bei Bedarf mehrere Ziellaufwerke ausgew�hlt werden. Sollten die physikalischen Gr��en der Laufwerke unterschiedlich sein, oder ist das Laufwerk schon als Quellaufwerk verwendet worden, kann das Quellaufwerk automatisch deaktiviert werden. Sollte innerhalb dieser Anzeige ein Problem mit der physikalischen Gr��e auftreten, erscheint ein entsprechender Hinweis.

Je nach dem Status der Laufwerksauswahl sind die Aktionskn�pfe `Lesen`, `Schreiben` und `Kopieren` anw�hlbar oder in Geisterschrift dargestellt.




## 1.2 Anzeigebereich 

Im Anzeigebereich rechts neben der Laufwerksauswahl werden in der Listenanzeige unter `Bearbeitet` die Namen der Datentr�ger aufgelistet. Je nach Art der Bearbeitung in in verschiedenen Farben:

schwarz:	gelesen,	�berpr�ft  
wei�:	geschrieben,	formatiert  
blau (Farbe 3):	kopiert

Rechts daneben befindet sich die Fehleranzeige, die nur Lesefehler in Farbe Schwarz darstellt (siehe hierzu \\\Anhang A). Bei allen anderen vorkommenden Fehler wie Schreib- oder �berpr�fungsfehler, wird der aktuelle Bearbeitungsvorgang abgebrochen.




## 1.3 Statusanzeige 

In der Statusanzeige wird links oben der momentane Bearbeitungsmodus angezeigt. Falls gerade auf dem Benutzer gewartet wird, oder ein anderes Fenster aktiv ist, steht hier einfach `warte...`.

W�hrend der Bearbeitung eines Datentr�gers f�llt sich die darunter liegende F�llstandsanzeige auf und zeigt zus�tzlich in Prozenten die bearbeiteten Spuren an. Rechts neben der F�llstandsanzeige liegt des `Stop!` Knopf, der zum Unterbrechen der aktuellen Funktion verwendet wird. Nat�rlich wird vorher vom Programm noch mal nachgefragt, ob nun auch wirklich der aktuelle Bearbeitungsvorgang unterbrochen werden soll.

Zur Komplettierung der Statusanzeige wird rechts daneben die aktuelle Spur sowie die schon verstrichene Zeit angezeigt.




## 1.4 Buffer 

Beim `Lesen` oder `Schreiben` k�nnen von oder in einen Buffer Daten ablegen. Die Art des Buffer kann durch den obersten Knopf, in dem sich beim Start des Programms der Text Speicher befinden sollte, ausgew�hlt werden. Es gibt davon drei verschiedene Arten, die nachfolgend Beschrieben werden.


### 1.4.1 Speicher 

Hier wird jeder frei verf�gbare Speicher hergenommen, um die Daten unterzubringen. �ber der Anzeige, des noch verf�gbaren Speicherplatzes wird noch der aktuelle Speicher-Packer (Siehe \\\Kapitel 2 Optionen) angezeigt.

Durch einen Druck auf `freigeben` kann nach dem Einlesen von Daten in dem Speicher der Buffer freigegeben werden.


### 1.4.2 Laufwerk 

Hier kann f�r die Daten ein Laufwerk angegeben werden. Momentan sollte hier das Laufwerk angezeigt werden, auf dem noch gen�gend Platz vorhanden ist. Falls dennoch der Buffer auf ein anderes Laufwerk verlegt werden soll, kann dies durch der Anwahl des rechts neben dem Laufwerknamen befindlichen "Pop-Up"-knopf unternommen werden. Hier erscheint dann ein Auswahlfenster mit einer Liste der angemeldeten Laufwerke, die durch einfaches Anklicken ausgew�hlt werden k�nnen. Mit `Abbruch`, wird nichts am aktuellen Laufwerksnamen ver�ndert.

Darunter noch die Anzeige der freien Bytes auf dem angew�hlten Laufwerk, sowie Laufwerk-Packer, der in den Optionen (\\\Kapitel 2) eingestellt werden kann.

Falls Daten schon einmal eingelesen `Lesen` wurden, k�nnen die Daten durch einen Druck auf `freigeben` gel�scht werden.

Beachten Sie bitte, da� in keinem Fall irgendwelche Daten auf dem angegebenen Laufwerk gel�scht werden.


### 1.4.3 Datei 

Hier kann ein beliebiger Dateiname angegeben werden, in dem oder von dem die Daten gespeichert oder gelesen werden k�nnen. Ab *Kickstart 2.0*  kann hier die Auswahl der Datei durch den rechts daneben liegenden "PopUp"-knopf durch den *Dateienrequester "ASL"* erleichtert werden. Unter *Kickstart 1.3* oder 1.2 wird dieser Knopf erst gar nicht angezeigt. Hier mu� der Dateiname per Hand eingegeben werden.

Wie gewohnt wird darunter der Datei-Packer sowie die Anzahl der freien Bytes auf dem Datentr�ger, der die Datei enth�lt oder enthalten wird, angezeigt.


### 1.4.4 Bufferinfo 

W�hrend dem Lesen in einem Buffer ver�ndert sich die Buffer-Anzeige in die Bufferinfo-Anzeige:

Rechts neben "Out" wird die Anzahl der komprimierten bis jetzt ausgegebenen Bytes angezeigt, und neben "In" die Anzahl der unkomprimierten Bytes, die bis jetzt eingelesen wurden.

Darunter erscheint der aktuelle Packer, die Packrate sowie die Anzahl der freien Bytes auf dem angesprochenem Medium (Speicher oder Laufwerk).




## 1.5 Spurbereich 

Zwischen den Buffereinstellungen und den Aktionskn�pfe kann der Spurbereich eingestellt werden. Bei der Anwahl eines Quellaufwerkes werden hier automatisch die Start- und Endspur �bertragen, die durch die zwei Eingabefelder neben "Von" und "bis" ge�ndert werden k�nnen.

Beachten Sie bitte, da� diese Einstellungen nur f�r das Quellaufwerk gelten. Bei `Schreiben`, wo ja der Buffer verwendet wird, wird die Start- und Endspur ignoriert.




# 2 Optionen 

Mit einem Klick auf `Optionen...` erscheint ein Fenster, in dem einige Parameter eingestellt werden k�nnen.



### Datum anpassen 

-  Ist hier ein Haken gesetzt, wird bei einem Schreibvorgang das Datum der Diskette aktualisiert. Dieser Punkt ist voreingestellt, da durch ein Fehler in der Kickstart 1.3 der Computer bei der Erkennung von zwei gleichen Disketten abst�rzt. 

### Pr�flesen 

-  Durch setzen dieser Option werden die Daten nach dem Schreiben nochmals zur �berpr�fung gelesen gelesen. Sollte aus Sicherheitsgr�nden immer angew�hlt sein. 

### Leseversuche 

-  Falls Fehler beim Einlesen von Daten auftreten, wird solange die defekte Spur nochmals gelesen und �berpr�ft, bis die hier angegebenen Leseversuche durchgef�hrt worden sind. Voreingestellt sind 5. 

### Packer 

Wie schon in den vorherigen Kapiteln beschrieben, k�nnen hier die Packer mit Hilfe von "Pop-Up"-kn�pfen f�r die verschiedenen Buffer-Typen eingestellt werden.


Nachdem die Parameter ver�ndert wurden, k�nnen sie mit einem Druck auf `Sichern` fest gespeichert werden, oder mit `Verwenden` nur bis zur Beendigung von COP! gesetzt werden.

Mit `Abbruch` werden alle Ver�nderungen an den Parametern verworfen.



# 3 Inhalt 


Manchmal ist es vor dem �berkopieren oder Formatieren eines Datentr�gers wichtig zu wissen, welche Dateien sich darauf befinden.

Nach Druck `Inhalt` erscheint im selben Fenster eine Laufwerksauswahl sowie drei Verzeichnis-Auswahlfelder. Von links nach rechts k�nnen nun durch Dr�cken auf die jeweiligen Laufwerke oder Verzeichnisse drei Ebenen der Verzeichnisstruktur angezeigt werden.




# 4 Aktionskn�pfe 


## 4.1 Lesen 

Falls ein Quellaufwerk angew�hlt wurde, kann hier in einem der Buffer die Daten des angew�hlten Laufwerkes eingelesen werden. Wenn der Buffer schon vorhanden ist, und noch nicht wieder zur�ckgeschrieben wurde, oder beim Datei-Buffer die Datei schon vorhanden ist, erscheint hier vorher noch eine Sicherheitsabfrage.

Um `Lesen` abzubrechen, ist ein Druck auf `Stop!` n�tig.


## 4.2 Schreiben 

Hier werden die Daten auf die angew�hlten Ziellaufwerk zur�ckkopiert. Die Spurangaben werden in diesem Fall vom Buffer �bernommen. Falls die physikalische Gr��e der Daten des Buffers nicht mit den Ziellaufwerk(en) �bereinstimmt, wird ein entsprechender Hinweis erscheinen und der eigentliche Schreibvorgang nicht gestartet.

Abgebrochen kann die Schreibfunktion durch `Stop!` werden.


## 4.3 Kopieren 

Wenn sowohl ein Quellaufwerk als auch ein oder mehrere Ziellaufwerke vorhanden sind, k�nnen die Daten mit dieser Funktion direkt kopiert werden.

Das Abbrechen ist mit einem Klick auf `Stop!` m�glich.


## 4.4 �berpr�fen 

Hiermit wird das aktuelle Quellaufwerk �berpr�ft. Ein Abbrechen ist auch hier durch einen Klick auf `Stop!` m�glich.


## 4.5 Formatieren 

Hier wird nicht wie �blich bei den anderen Aktionskn�pfen die Bearbeitung sofort gestartet, sondern es erscheint vielmehr zuerst ein Fenster, in dem noch einige Einstellungen gemacht werden k�nnen:

### Name des Datentr�gers 

-  Hier steht der Name den der Datentr�ger nach der Formatierung bekommen soll. Voreingestellt ist "Leer". 

### File System 

-  Momentan kann nur aus zwei File-Systeme ausgew�hlt werden. Fast File System und Old File System. Voreingestellt ist hier das Old File System. 

### Internationaler Modus 

Hier k�nnen Sie den internationalen Modus ausw�hlen. Dieser Modus ist nur dann sinnvoll, wenn Umlaute als Verzeichnis- oder Dateinamen verwendet werden.

### schnelle Formatierung 

Wird dieser Punkt hier abgehakt, wird der Datentr�ger *soft-formatiert*. Das Programm geht davon aus, da� alle Datenbl�cke schon formatiert sind, und der Datentr�ger nur gel�scht werden soll. In diesem Fall wird nur der *Bootblock* und der *Rootblock* beschrieben.


### Formatieren 

Nach der Anwahl von `Formatieren` wird nun endlich die Formatierung der Ziellaufwerke gestartet.


### Abbruch 

Hiermit kann die Formatierung abgebrochen werden.




# Anhang A Tastaturk�rzel 

Folgende *Tastaturk�rzel* k�nnen bei COP! verwendet werden:

Basisfenster:

`s`	Stop!

`e`	Bufferumschaltung  
`r`	Freigabe eines Laufwerks oder von Speicher

`o`	Optionen  
`i`	Inhalt

`l`	Lesen  
`s`	Schreiben  
`k`	Kopieren  
`p`	�berpr�fen  
`f`	Formatieren

Formatieren-Fenster:

`f`	File System umstellen.  
`i`	internationaler Modus an/aus  
`s`	schnelle Formatierung an/aus  
`Return`	Formatierung beginnen  
`Abbruch`	Abbruch

Optionen, Packer-Auswahl, Laufwerk-Auswahl und Inhalt-Fenster:

`Esc`	Abbruch

Verschiedene Hinweisfenster:

`v`	OK! (linker Knopf)  
`b`	Abbruch (rechter Knopf)

