\\\ Referenz


Inhaltsverzeichnis COP!

Einleitung

1	Oberfläche  
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

4	Aktionsknöpfe

4.1	Lesen  
4.2	Schreiben  
4.3	Kopieren  
4.4	Überprüfen  
4.5	Formatieren

Anhang A	Tastaturkürzel  
Anhang B	Fehlermeldungen beim Datenzugriff \\\ ****((((siehe TOP!)))****

# Einleitung 

Da auf Datenträger wie Disketten oder manchen Festplatten Fehler auftreten können, sollten von wichtigen Programmen Sicherheitskopien angefertigt werden. COP! bietet nun diese Möglichkeit mit einigen interessanten Zusatzfunktionen, wie die Überprüfung und Formatierung von Datenträgern, sowie das Archivieren von Disketten mit Hilfe eines *externen Komprimierers*.




# 1 Oberfläche 

Wie gewohnt wird COP! durch einen Doppelklick auf dessen Icon gestartet. Kurz darauf sollte die Oberfläche erscheinen, die in drei vertikale Bereiche aufgeteilt ist.

Im oberen Bereich befindet sich links die Laufwerksauswahl (`Quelle`, `Ziel(e)` und rechts der Listenanzeigebereich, wo zuerst die schon bearbeiteten Datenträger aufgelistet werden, und rechts daneben die Fehler im letzten Bearbeitungsvorgang.

Darunter befindet sich ein kleinerer Bereich, der den *aktuellen Status* anzeigt (momentan steht hier "warte..."), sowie eine *Füllstandsanzeige* mit Prozentangabe, die das Fortschreiten eines *Bearbeitungsvorganges* anzeigt. An der Füllstandsanzeige befindet sich noch der `Stop!`-knopf, der das Unterbrechen jedes Bearbeitungsvorganges erlaubt. Rechts daneben wird noch die aktuelle Spur sowie die seit dem Start verstrichene Zeit in Stunden, Minuten und Sekunden angezeigt.

Im untersten Bereich des Fensters sind die Buffer-Einstellungen, sowie die Spureinstellungen und Aktionsknöpfe plaziert.




## 1.1 Laufwerksauswahl 

Links oben im Fenster von COP! befinden sich zwei Listenanzeigen, in denen Ihre angemeldeten Laufwerke dargestellt werden sollen.

In der Listenanzeige, die mit `Quelle` bezeichnet ist, wird das Quellaufwerk angewählt. Von diesem Laufwerk können also nur Daten gelesen werden. Wird hier ein Laufwerk angewählt, das nicht der physikalischen Größen eines Ziellaufwerkes entspricht oder schon als Ziellaufwerk angegeben wurde, wird das Laufwerk in der Ziel-Listenanzeige deaktiviert.

Rechts daneben befindet sich die Laufwerksauswahl für das oder die Ziellaufwerke. Hier können bei Bedarf mehrere Ziellaufwerke ausgewählt werden. Sollten die physikalischen Größen der Laufwerke unterschiedlich sein, oder ist das Laufwerk schon als Quellaufwerk verwendet worden, kann das Quellaufwerk automatisch deaktiviert werden. Sollte innerhalb dieser Anzeige ein Problem mit der physikalischen Größe auftreten, erscheint ein entsprechender Hinweis.

Je nach dem Status der Laufwerksauswahl sind die Aktionsknöpfe `Lesen`, `Schreiben` und `Kopieren` anwählbar oder in Geisterschrift dargestellt.




## 1.2 Anzeigebereich 

Im Anzeigebereich rechts neben der Laufwerksauswahl werden in der Listenanzeige unter `Bearbeitet` die Namen der Datenträger aufgelistet. Je nach Art der Bearbeitung in in verschiedenen Farben:

schwarz:	gelesen,	überprüft  
weiß:	geschrieben,	formatiert  
blau (Farbe 3):	kopiert

Rechts daneben befindet sich die Fehleranzeige, die nur Lesefehler in Farbe Schwarz darstellt (siehe hierzu \\\Anhang A). Bei allen anderen vorkommenden Fehler wie Schreib- oder Überprüfungsfehler, wird der aktuelle Bearbeitungsvorgang abgebrochen.




## 1.3 Statusanzeige 

In der Statusanzeige wird links oben der momentane Bearbeitungsmodus angezeigt. Falls gerade auf dem Benutzer gewartet wird, oder ein anderes Fenster aktiv ist, steht hier einfach `warte...`.

Während der Bearbeitung eines Datenträgers füllt sich die darunter liegende Füllstandsanzeige auf und zeigt zusätzlich in Prozenten die bearbeiteten Spuren an. Rechts neben der Füllstandsanzeige liegt des `Stop!` Knopf, der zum Unterbrechen der aktuellen Funktion verwendet wird. Natürlich wird vorher vom Programm noch mal nachgefragt, ob nun auch wirklich der aktuelle Bearbeitungsvorgang unterbrochen werden soll.

Zur Komplettierung der Statusanzeige wird rechts daneben die aktuelle Spur sowie die schon verstrichene Zeit angezeigt.




## 1.4 Buffer 

Beim `Lesen` oder `Schreiben` können von oder in einen Buffer Daten ablegen. Die Art des Buffer kann durch den obersten Knopf, in dem sich beim Start des Programms der Text Speicher befinden sollte, ausgewählt werden. Es gibt davon drei verschiedene Arten, die nachfolgend Beschrieben werden.


### 1.4.1 Speicher 

Hier wird jeder frei verfügbare Speicher hergenommen, um die Daten unterzubringen. Über der Anzeige, des noch verfügbaren Speicherplatzes wird noch der aktuelle Speicher-Packer (Siehe \\\Kapitel 2 Optionen) angezeigt.

Durch einen Druck auf `freigeben` kann nach dem Einlesen von Daten in dem Speicher der Buffer freigegeben werden.


### 1.4.2 Laufwerk 

Hier kann für die Daten ein Laufwerk angegeben werden. Momentan sollte hier das Laufwerk angezeigt werden, auf dem noch genügend Platz vorhanden ist. Falls dennoch der Buffer auf ein anderes Laufwerk verlegt werden soll, kann dies durch der Anwahl des rechts neben dem Laufwerknamen befindlichen "Pop-Up"-knopf unternommen werden. Hier erscheint dann ein Auswahlfenster mit einer Liste der angemeldeten Laufwerke, die durch einfaches Anklicken ausgewählt werden können. Mit `Abbruch`, wird nichts am aktuellen Laufwerksnamen verändert.

Darunter noch die Anzeige der freien Bytes auf dem angewählten Laufwerk, sowie Laufwerk-Packer, der in den Optionen (\\\Kapitel 2) eingestellt werden kann.

Falls Daten schon einmal eingelesen `Lesen` wurden, können die Daten durch einen Druck auf `freigeben` gelöscht werden.

Beachten Sie bitte, daß in keinem Fall irgendwelche Daten auf dem angegebenen Laufwerk gelöscht werden.


### 1.4.3 Datei 

Hier kann ein beliebiger Dateiname angegeben werden, in dem oder von dem die Daten gespeichert oder gelesen werden können. Ab *Kickstart 2.0*  kann hier die Auswahl der Datei durch den rechts daneben liegenden "PopUp"-knopf durch den *Dateienrequester "ASL"* erleichtert werden. Unter *Kickstart 1.3* oder 1.2 wird dieser Knopf erst gar nicht angezeigt. Hier muß der Dateiname per Hand eingegeben werden.

Wie gewohnt wird darunter der Datei-Packer sowie die Anzahl der freien Bytes auf dem Datenträger, der die Datei enthält oder enthalten wird, angezeigt.


### 1.4.4 Bufferinfo 

Während dem Lesen in einem Buffer verändert sich die Buffer-Anzeige in die Bufferinfo-Anzeige:

Rechts neben "Out" wird die Anzahl der komprimierten bis jetzt ausgegebenen Bytes angezeigt, und neben "In" die Anzahl der unkomprimierten Bytes, die bis jetzt eingelesen wurden.

Darunter erscheint der aktuelle Packer, die Packrate sowie die Anzahl der freien Bytes auf dem angesprochenem Medium (Speicher oder Laufwerk).




## 1.5 Spurbereich 

Zwischen den Buffereinstellungen und den Aktionsknöpfe kann der Spurbereich eingestellt werden. Bei der Anwahl eines Quellaufwerkes werden hier automatisch die Start- und Endspur übertragen, die durch die zwei Eingabefelder neben "Von" und "bis" geändert werden können.

Beachten Sie bitte, daß diese Einstellungen nur für das Quellaufwerk gelten. Bei `Schreiben`, wo ja der Buffer verwendet wird, wird die Start- und Endspur ignoriert.




# 2 Optionen 

Mit einem Klick auf `Optionen...` erscheint ein Fenster, in dem einige Parameter eingestellt werden können.



### Datum anpassen 

-  Ist hier ein Haken gesetzt, wird bei einem Schreibvorgang das Datum der Diskette aktualisiert. Dieser Punkt ist voreingestellt, da durch ein Fehler in der Kickstart 1.3 der Computer bei der Erkennung von zwei gleichen Disketten abstürzt. 

### Prüflesen 

-  Durch setzen dieser Option werden die Daten nach dem Schreiben nochmals zur Überprüfung gelesen gelesen. Sollte aus Sicherheitsgründen immer angewählt sein. 

### Leseversuche 

-  Falls Fehler beim Einlesen von Daten auftreten, wird solange die defekte Spur nochmals gelesen und überprüft, bis die hier angegebenen Leseversuche durchgeführt worden sind. Voreingestellt sind 5. 

### Packer 

Wie schon in den vorherigen Kapiteln beschrieben, können hier die Packer mit Hilfe von "Pop-Up"-knöpfen für die verschiedenen Buffer-Typen eingestellt werden.


Nachdem die Parameter verändert wurden, können sie mit einem Druck auf `Sichern` fest gespeichert werden, oder mit `Verwenden` nur bis zur Beendigung von COP! gesetzt werden.

Mit `Abbruch` werden alle Veränderungen an den Parametern verworfen.



# 3 Inhalt 


Manchmal ist es vor dem Überkopieren oder Formatieren eines Datenträgers wichtig zu wissen, welche Dateien sich darauf befinden.

Nach Druck `Inhalt` erscheint im selben Fenster eine Laufwerksauswahl sowie drei Verzeichnis-Auswahlfelder. Von links nach rechts können nun durch Drücken auf die jeweiligen Laufwerke oder Verzeichnisse drei Ebenen der Verzeichnisstruktur angezeigt werden.




# 4 Aktionsknöpfe 


## 4.1 Lesen 

Falls ein Quellaufwerk angewählt wurde, kann hier in einem der Buffer die Daten des angewählten Laufwerkes eingelesen werden. Wenn der Buffer schon vorhanden ist, und noch nicht wieder zurückgeschrieben wurde, oder beim Datei-Buffer die Datei schon vorhanden ist, erscheint hier vorher noch eine Sicherheitsabfrage.

Um `Lesen` abzubrechen, ist ein Druck auf `Stop!` nötig.


## 4.2 Schreiben 

Hier werden die Daten auf die angewählten Ziellaufwerk zurückkopiert. Die Spurangaben werden in diesem Fall vom Buffer übernommen. Falls die physikalische Größe der Daten des Buffers nicht mit den Ziellaufwerk(en) übereinstimmt, wird ein entsprechender Hinweis erscheinen und der eigentliche Schreibvorgang nicht gestartet.

Abgebrochen kann die Schreibfunktion durch `Stop!` werden.


## 4.3 Kopieren 

Wenn sowohl ein Quellaufwerk als auch ein oder mehrere Ziellaufwerke vorhanden sind, können die Daten mit dieser Funktion direkt kopiert werden.

Das Abbrechen ist mit einem Klick auf `Stop!` möglich.


## 4.4 Überprüfen 

Hiermit wird das aktuelle Quellaufwerk überprüft. Ein Abbrechen ist auch hier durch einen Klick auf `Stop!` möglich.


## 4.5 Formatieren 

Hier wird nicht wie üblich bei den anderen Aktionsknöpfen die Bearbeitung sofort gestartet, sondern es erscheint vielmehr zuerst ein Fenster, in dem noch einige Einstellungen gemacht werden können:

### Name des Datenträgers 

-  Hier steht der Name den der Datenträger nach der Formatierung bekommen soll. Voreingestellt ist "Leer". 

### File System 

-  Momentan kann nur aus zwei File-Systeme ausgewählt werden. Fast File System und Old File System. Voreingestellt ist hier das Old File System. 

### Internationaler Modus 

Hier können Sie den internationalen Modus auswählen. Dieser Modus ist nur dann sinnvoll, wenn Umlaute als Verzeichnis- oder Dateinamen verwendet werden.

### schnelle Formatierung 

Wird dieser Punkt hier abgehakt, wird der Datenträger *soft-formatiert*. Das Programm geht davon aus, daß alle Datenblöcke schon formatiert sind, und der Datenträger nur gelöscht werden soll. In diesem Fall wird nur der *Bootblock* und der *Rootblock* beschrieben.


### Formatieren 

Nach der Anwahl von `Formatieren` wird nun endlich die Formatierung der Ziellaufwerke gestartet.


### Abbruch 

Hiermit kann die Formatierung abgebrochen werden.




# Anhang A Tastaturkürzel 

Folgende *Tastaturkürzel* können bei COP! verwendet werden:

Basisfenster:

`s`	Stop!

`e`	Bufferumschaltung  
`r`	Freigabe eines Laufwerks oder von Speicher

`o`	Optionen  
`i`	Inhalt

`l`	Lesen  
`s`	Schreiben  
`k`	Kopieren  
`p`	Überprüfen  
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

