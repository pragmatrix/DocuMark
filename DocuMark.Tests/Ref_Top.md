Inhaltsverzeichnis TOP!



Einf�hrung

1	Das Programm  
1.1	Laufwerksauswahl  
1.2	Ziellaufwerk  
1.3	Pr�fen  
1.3.1	Pr�fen unterbrechen  
1.4	Scan  
1.4.1	Laufwerk freigeben  
1.5	Optimieren  
1.5.1	WB-Modus  
1.5.2	CLI-Modus  
1.5.3	ReadBuff  
1.5.4	Gfx-Anzeige  
1.5.5	Verbrauch  
1.5.6	Start  
1.6	TOP! beenden

Anhang A	Statusanzeige  
Anhang B	Tastaturk�rzel  
Anhang C	Fehlermeldungen beim Datenzugriff

# Einf�hrung 

Durch h�ufige Zugriffe auf Datentr�gern seien es Festplatten oder Disketten, k�nnen systembedingt die Zugriffsgeschwindigkeiten auf einzelne Dateien merkbar herabsinken. Die Dateien werden ungewollt zerst�ckelt und an mehreren verschiedenen Positionen auf dem Datentr�ger verteilt. Diese *Fragmentierungen* treten h�ufig dann auf, wenn auf einem Datentr�ger Dateien h�ufig gel�scht oder umkopiert werden.

Diesem Problem widmet sich nun TOP!. TOP! versucht mit einigen relativ komplizierten Algorithmen die Dateien zu defragmentieren und neu anzulegen.




# 1 Das Programm 

Nach dem Start von TOP! mit einem Doppelklick erscheint auf der Workbench die *Oberfl�che*, die in verschiedenen Bereichen unterteilt ist. Die nachfolgend in funktionsbezogener Reihenfolge beschrieben werden.




## 1.1 Laufwerksauswahl 


In der Mitte des Fensters (unter dem `Laufw. freig.` Knopf) befindet sich die Laufwerksauswahl, in der mindestens das Laufwerk "DF0:" erscheinen sollte. Bevor irgendeine weitere Funktion ausgew�hlt wird, sollte zuerst das zu bearbeitende Laufwerk angew�hlt werden.

Mit einem Doppelklick auf das Laufwerk ist die Anzeige von einigen physikalischen Informationen des Datentr�gers m�glich. Mit einem Druck auf `OK!` verschwindet das Laufwerksinformationsfenster wieder.

Nach der Aktivierung des Laufwerks, k�nnen weitere Funktionen angew�hlt werden. Um von einen Datentr�ger auf einen zweiten zu optimieren ist es bei Bedarf m�glich ein Ziellaufwerk mit Hilfe von `Ziel` und der darunterliegenden zweiten Laufwerksauswahl anzuw�hlen. Dies ist besonders aus Sicherheitsgr�nden sinnvoll, oder falls wenig Speicherplatz vorhanden ist. Nat�rlich ist es hier nur m�glich auf einen Datentr�ger zu optimieren, der die selbe physikalische Gr��e hat.




## 1.2 Ziellaufwerk 


Mit dem Knopf `Ziel` wird ein Ziellaufwerk aktiviert. Ist `Ziel` nicht angew�hlt, wird eine eventuelle Optimierung nur auf einem Laufwerk durchgef�hrt. Das Ziellaufwerk kann bei einem *abgehakten* `Ziel` Knopf mit der darunter befindlichen Laufwerksauswahl eingestellt werden.

Bitte beachten Sie, da� die Laufwerke die selbe physikalische Gr��e haben m�ssen. Falls dennoch verschieden gro�e Laufwerke eingestellt wurden, wird vor der Optimierung ein entsprechender Hinweis ausgegeben.

Auch hier k�nnen durch einen Doppelklick Informationen �ber ein bestimmtes Laufwerk ausgegeben werden.

Wie angesprochen hat die Optimierung auf ein anderes Laufwerk den Vorteil, da� hierdurch keine Daten zerst�rt werden k�nnen und da� der Optimierungsvorgang durch die ausfallende Sortierung und Zwischenlagerung der Datenbl�cke verschnellert wird.




## 1.3 Pr�fen 

Nach Auswahl eines Laufwerks sollte zun�chst bei der erstmaligen Verwendung von TOP! die �berpr�fung gestartet werden. Die �berpr�fung versucht einfach alle Datenbl�cke des Tr�gers einmal in den Speicher zu lesen, um sicherzugehen, da� sich keine schwerwiegenden Fehler auf dem Datentr�ger befinden.

Beim Start der *Pr�fvorgang* werden einige Ver�nderungen in dem Fenster erkennbar. Zuerst werden alle m�glichen Kn�pfe mit einem schwarzen Punktemuster �berzogen, um deren Auswahl zu vermeiden. Links in der Mitte wechselt die Statusanzeige von "warte..." auf "Pr�fen". Wenn die Diskette richtig eingelegt ist, und sie auch vom Betriebssystem als DOS-Diskette erkannt wurde, startet die trackweise �berpr�fung.

W�hrend der �berpr�fung wird die *Trackanzeige*, die sich links oben im gr��ten abgetrennten Bereich des Fensters befindet, je nach Anzahl der schon �berpr�ften Spuren, aufgef�llt. Rechts neben der *Statusanzeige* befindet sich eine F�llanzeige, die sich von links nach rechts auff�llt und zus�tzlich noch den prozentualen Wert der schon �berpr�ften Datenbl�cke enth�lt.

Diese drei Anzeige-Komponenten (Trackanzeige, Statusanzeige und Fortschrittsanzeige) werden auch in den Funktionen Scan und Optimieren verwendet.

Der Pr�fvorgang kann jederzeit mit einem Druck auf `Stop` oder `s` abgebrochen werden.

Nach einer erfolgreichen �berpr�fung sollte eine Best�tigung erscheinen, da� sich keine Fehler auf dem Datentr�ger befinden. Falls ein Fehler aufgetreten ist, sollte die Optimierung anschlie�end nicht gestartet werden. Auch falls ein nachtr�gliches *scannen* des Laufwerks keine Fehler ausgibt, ist von einer Optimierung abzuraten.




## 1.4 Scan 

Vor der Optimierung mu� das Laufwerk immer zuerst *gescannt* werden. `Scan` analysiert und speichert die komplette Verzeichnisstruktur Ihres Datentr�gers, und kann nach der erfolgreichen Verarbeitung dieser Informationen dem Benutzer genau mitteilen, wie stark die auf dem Datentr�ger befindlichen Dateien fragmentiert sind.

W�hrend dem *Scannvorgang* werden keine Daten geschrieben. `Scan` kann also getrost auf alle m�glichen Festplattenpartitionen oder Disketten losgelassen werden, um den Grad der Verw�stung anzuzeigen.

Nach einem Druck auf `Scan` werden wie bei "Pr�fen" fast alle Kn�pfe mit einem Schwarzschleier �berzogen. Die Statusanzeige wechselt um in "Scannen", und die Trackanzeige oben links zeigt nun dunkle und helle Punkte oder Striche an (Alle Farbangaben beziehen sich auf die Standardfarben einer Workbench 2.x). Jeder dieser Farbkleckser ist ein Block auf dem Datentr�ger. Ein heller Klecks ist ein Infoblock, der nur zur Verwaltung der Daten vorhanden ist. Ein dunkler Klecks ist ein Datenblock.

Der *Scannvorgang* kann jederzeit mit `Stop` abgebrochen werden.

Je nach dem wie diese Farben in der Trackanzeige verteilt sind, f�llt auch dann das Scan-Ergebnis aus, das nach dem *Scannvorgang* erscheint.

Zwei Werte werden hier ausgegeben, von denen der erste der wichtigere ist. Dieser Wert gibt die Anzahl der Dateien in Prozent an, die mindestens in zwei Teile zerteilt sind. Sind also zum Beispiel 20% fragmentiert, ist durchschnittlich jede f�nfte Datei in ein oder mehrere Teile zerst�ckelt!

Die Anzeige der "fragmentierten Infos" ist mehr f�r die wirklichen CLI-Freaks gedacht. Desto kleiner dieser Wert, desto schneller k�nnen Verzeichnisse vom CLI aus angezeigt werden. Da die Workbench zus�tzlich zu den Verzeichnissen noch Icons mitspeichert, und diese dann beim Lesen einl�dt, gibt es hierf�r eine andere Optimierungsart.

Das Fenster mit dem *Scan-Ergebnis* kann durch einen Klick auf `OK!` verlassen werden.


### 1.4.1 Laufwerk freigeben 

TOP! geht nach dem erfolgreichen *scannen* eines Datentr�gers davon aus, da� dieses Laufwerk danach optimiert wird. Da TOP! sichergehen will, da� keine Informationen auf dem Datentr�ger ge�ndert werden, bleibt das Laufwerk in den H�nden von TOP!.

Um auf das Laufwerk in diesem Fall wieder zuzugreifen, ist ein Klick auf `Laufw. freig.` n�tig.

Wenn eine Optimierung ohne vorherigem Scannen gestartet wird, wird Scan automatisch durchgef�hrt.




## 1.5 Optimieren 

Kommen wir nun zum Hauptpunkt von TOP!. Das Optimieren. Bevor aber der Hauptgang gestartet wird, sollten folgende Parameter noch �berpr�ft, beziehungsweise ver�ndert werden.


### 1.5.1 WB-Modus 

Der `WB-Modus` sollte bei einer intensiven Nutzung der Workbench eingestellt werden.

In diesem speziellen Optimierungsmodus werden die Icons, die auf der Workbench plaziert sind zwischen die Informationsbl�cke gelegt. Es entsteht dadurch bei der Benutzung der Workbench ein merkbarer Geschwindigkeitsvorteil beim �ffnen von Verzeichnissen.


### 1.5.2 CLI-Modus 

Falls haupts�chlich mit dem *CLI* gearbeitet wird, ist eine Optimierung mit dem `CLI-Modus` wohl am besten geeignet. Hier werden einfach nur die Informationsbl�cke aneinandergereiht, um das m�glichst schnelle Lesen eines Verzeichnisses zu verschnellern.


### 1.5.3 ReadBuff 

Hier kann optional ein zus�tzlicher Trackbuffer beim Lesen eingestellt werden. Je nach Laufwerk und Fragmentierung k�nnen sich durch das Einschalten von `ReadBuff` erhebliche Geschwindigkeitsvorteile ergeben.


### 1.5.4 Gfx-Anzeige 

Da der Aufbau der linken oberen Trackanzeige beim Optimieren relativ Aufwendig ist, und teilweise auf langsameren Prozessoren in der *Optimierungszeit* bemerkbar wird, kann sie hier ausgeschaltet werden.


### 1.5.5 Verbrauch 

Hier kann der ungef�hre Speicherverbrauch von TOP! mit den Pfeiltasten eingestellt werden. Ist der links neben den Tasten befindliche Bereich aufgef�llt, wird fast der gesamte Speicher f�r die Zwischenspeicherung der Datenbl�cke hergenommen. Ist er leer, wird so wenig wie n�tig verwendet.

Die Anzahl der freien Bytes im Hauptspeicher kann jederzeit rechts unten unter "Bytes frei" abgelesen werden.



### 1.5.6 Start 

Nach den oben beschriebenen Einstellung kann nun die Optimierung begonnen werden. Falls vorher noch nicht gescannt wurde, oder vielleicht einige wichtige Parameter ge�ndert wurden, wird der *Scannvorgang* nochmals gestartet. Wobei diesmal kein Scan-Ergebnis mehr ausgegeben wird. Auch ist nun eine Unterbrechung nicht mehr m�glich!

Bitte vergewissern Sie sich vorher, da� Sie sich eine *Sicherheitskopie* von den wichtigsten Daten angelegt haben!

Bitte beachten Sie auch, da� nicht schon optimierte Datentr�ger optimiert werden, da sich dadurch systembedingt gr��ere interne Berechnungszeiten beim Status "Bewegen" ergeben k�nnen!

Nach dem Scannen des Datentr�gers f�hrt die Optimierung noch einige interne Tests durch, und beginnt dann mit dem Kopieren der Daten. Zuerst werden Daten an beliebigen Positionen in den Speicher gelesen (hell dargestellt), und dann wieder zur�ckgespeichert (in blau dargestellt). Dieser Vorgang wiederholt sich solange, bis keine Datenbl�cke mehr vorhanden sind. Die Geschwindigkeit ist abh�ngig von der Anzahl der Datenbl�cke, von der Geschwindigkeit Ihres Laufwerkes sowie die Menge des Speichers, die dem Programm zum Verschieben der Daten zur Verf�gung gestellt wurde.

Bitte beachten Sie, da� bei einer Unterbrechung w�hrend der Optimierung durch z.B. Ausschalten des Computers wichtige Daten verloren gehen k�nnen!




## 1.6 TOP! beenden 

Das Programm kann entweder durch einen Druck auf den Schlie�knopf links oben am Fenster beendet werden, oder durch einen Druck auf den `Ende` Knopf.




### Anhang A Statusanzeige 


Die Statusanzeige kann folgende Aktionen anzeigen:

warte...

-  Hier wird auf eine Eingabe des Benutzers gewartet 

Pr�fen

-  Momentan wird ein Datentr�ger �berpr�ft 

Scannen

-  Der Scannvorgang ist in Aktion 

Korrigieren

-  Die gescannten Bl�cke werden im Speicher korrigiert 

Sortieren

-  Die gescannten Bl�cke werden im Speicher sortiert 

LRTest

-  Aus Geschwindigkeitsgr�nden wird hier �berpr�ft, wierum ein Datentr�ger optimiert werden soll. 

Bewegen

-  Diese Funktion findet heraus, welche Bl�cke im n�chsten Verschiebevorgang bearbeitet werden m�ssen. Teilweise kann diese Funktion relativ viel Zeit in Anspruch nehmen. 

Lesen

-  Nun werden die Daten eingelesen 

Koordinieren

-  Die Zeiger aller eingelesenen Informationsbl�cke werden korrigiert. 

Schreiben

-  Die Daten werden wieder zur�ckgeschrieben. 




## Anhang B Tastaturk�rzel 

Im Fenster von TOP! sind die meisten Funktionen durch die folgenden Tastaturk�rzel ausw�hlbar:

Einstellungen:

`r`	ReadBuff  
`g`	Gfx-Anzeige  
`w`	WB-Modus  
`c`	CLI-Modus

Verbrauch:

`v`	Verbrauch +10%  
`V`	Verbrauch -10%

Laufwerksauswahl:

`l`	Laufwerk freigeben  
`z`	Ziel

Aktionskn�pfe

`p`	Pr�fen  
`s`	Scan  
`s`	Stop...  
`o`	Optimieren...  
`�`	�ber...  
`e`	Ende

Verschiedene Hinweisfenster:

`v`	Best�tigung (linker Knopf)  
`b`	Abbruch (rechter Knopf)




## Anhang C Fehlermeldungen beim Datenzugriff 


Folgende Fehler k�nnen beim Lesen oder Schreiben von Daten vorkommen:

Kein Sektor-Header  
Falsche Sektor-Preamble  
Falsche Sektor-ID  
Falsche Header-Pr�fsumme  
Falsche Sektor-Pr�fsumme  
Zu wenige Sektoren  
Falscher Sektor-Header

-  Alle diese Fehlermeldungen deuten darauf hin, da� ein Sektor beziehungsweise eine Spur defekt ist. 

Schreibgesch�tzt

-  Der Datentr�ger ist schreibgesch�tzt. 

Diskette gewechselt

-  Die Diskette wurde aus dem Laufwerk entfernt oder es war keine eingelegt. 

Seek Fehler

-  Die Spur 0 wurde nicht gefunden. Dieser Fehler kann auf einen Hardwaredefekt Ihres Laufwerks hindeuten. 

Kein Speicher

-  Es ist zu wenig Speicher vorhanden. 

Laufwerk wird benutzt

-  Das Laufwerk wird gerade von jemanden benutzt. Bitte starten Sie den Vorgang nochmals. 


Falsche Unit  
Falscher Laufwerkstyp

-  Interne Fehler, die nicht auftreten sollten. 

