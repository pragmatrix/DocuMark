Referenzdokumation zur Amiga Software TOP!, die 1992 von Markt & Technik unter dem Namen "Simplex Tools" veröffentlicht wurde.

TOP! ist ein Anwenderprogramm für den Amiga, das Festplatten defragmentiert.

Die Kompatibilität mit aktuellen Amiga Systemen kann nicht garantiert werden. Bitte sichern Sie alle wichtigen Daten vor der Verwendung. Jegliche Haftung ist ausgeschlossen.

Diese Referenz wurde von Guido Ruhl verfasst und mit freundlicher Erlaubnis von Pearson ​Deutschland GmbH für die Freeware Veröffentlichung von RAP!TOP!COP! zur Verfügung gestellt.

(c) 1992 Pearson ​Deutschland GmbH

# Inhaltsverzeichnis 

Einführung

1	Das Programm  
1.1	Laufwerksauswahl  
1.2	Ziellaufwerk  
1.3	Prüfen  
1.3.1	Prüfen unterbrechen  
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
Anhang B	Tastaturkürzel  
Anhang C	Fehlermeldungen beim Datenzugriff

# Einführung 

Durch häufige Zugriffe auf Datenträgern seien es Festplatten oder Disketten, können systembedingt die Zugriffsgeschwindigkeiten auf einzelne Dateien merkbar herabsinken. Die Dateien werden ungewollt zerstückelt und an mehreren verschiedenen Positionen auf dem Datenträger verteilt. Diese *Fragmentierungen* treten häufig dann auf, wenn auf einem Datenträger Dateien häufig gelöscht oder umkopiert werden.

Diesem Problem widmet sich nun TOP!. TOP! versucht mit einigen relativ komplizierten Algorithmen die Dateien zu defragmentieren und neu anzulegen.




# 1 Das Programm 

Nach dem Start von TOP! mit einem Doppelklick erscheint auf der Workbench die *Oberfläche*, die in verschiedenen Bereichen unterteilt ist. Die nachfolgend in funktionsbezogener Reihenfolge beschrieben werden.




## 1.1 Laufwerksauswahl 


In der Mitte des Fensters (unter dem `Laufw. freig.` Knopf) befindet sich die Laufwerksauswahl, in der mindestens das Laufwerk "DF0:" erscheinen sollte. Bevor irgendeine weitere Funktion ausgewählt wird, sollte zuerst das zu bearbeitende Laufwerk angewählt werden.

Mit einem Doppelklick auf das Laufwerk ist die Anzeige von einigen physikalischen Informationen des Datenträgers möglich. Mit einem Druck auf `OK!` verschwindet das Laufwerksinformationsfenster wieder.

Nach der Aktivierung des Laufwerks, können weitere Funktionen angewählt werden. Um von einen Datenträger auf einen zweiten zu optimieren ist es bei Bedarf möglich ein Ziellaufwerk mit Hilfe von `Ziel` und der darunterliegenden zweiten Laufwerksauswahl anzuwählen. Dies ist besonders aus Sicherheitsgründen sinnvoll, oder falls wenig Speicherplatz vorhanden ist. Natürlich ist es hier nur möglich auf einen Datenträger zu optimieren, der die selbe physikalische Größe hat.




## 1.2 Ziellaufwerk 


Mit dem Knopf `Ziel` wird ein Ziellaufwerk aktiviert. Ist `Ziel` nicht angewählt, wird eine eventuelle Optimierung nur auf einem Laufwerk durchgeführt. Das Ziellaufwerk kann bei einem *abgehakten* `Ziel` Knopf mit der darunter befindlichen Laufwerksauswahl eingestellt werden.

Bitte beachten Sie, daß die Laufwerke die selbe physikalische Größe haben müssen. Falls dennoch verschieden große Laufwerke eingestellt wurden, wird vor der Optimierung ein entsprechender Hinweis ausgegeben.

Auch hier können durch einen Doppelklick Informationen über ein bestimmtes Laufwerk ausgegeben werden.

Wie angesprochen hat die Optimierung auf ein anderes Laufwerk den Vorteil, daß hierdurch keine Daten zerstört werden können und daß der Optimierungsvorgang durch die ausfallende Sortierung und Zwischenlagerung der Datenblöcke verschnellert wird.




## 1.3 Prüfen 

Nach Auswahl eines Laufwerks sollte zunächst bei der erstmaligen Verwendung von TOP! die Überprüfung gestartet werden. Die Überprüfung versucht einfach alle Datenblöcke des Trägers einmal in den Speicher zu lesen, um sicherzugehen, daß sich keine schwerwiegenden Fehler auf dem Datenträger befinden.

Beim Start der *Prüfvorgang* werden einige Veränderungen in dem Fenster erkennbar. Zuerst werden alle möglichen Knöpfe mit einem schwarzen Punktemuster überzogen, um deren Auswahl zu vermeiden. Links in der Mitte wechselt die Statusanzeige von "warte..." auf "Prüfen". Wenn die Diskette richtig eingelegt ist, und sie auch vom Betriebssystem als DOS-Diskette erkannt wurde, startet die trackweise Überprüfung.

Während der Überprüfung wird die *Trackanzeige*, die sich links oben im größten abgetrennten Bereich des Fensters befindet, je nach Anzahl der schon überprüften Spuren, aufgefüllt. Rechts neben der *Statusanzeige* befindet sich eine Füllanzeige, die sich von links nach rechts auffüllt und zusätzlich noch den prozentualen Wert der schon überprüften Datenblöcke enthält.

Diese drei Anzeige-Komponenten (Trackanzeige, Statusanzeige und Fortschrittsanzeige) werden auch in den Funktionen Scan und Optimieren verwendet.

Der Prüfvorgang kann jederzeit mit einem Druck auf `Stop` oder `s` abgebrochen werden.

Nach einer erfolgreichen Überprüfung sollte eine Bestätigung erscheinen, daß sich keine Fehler auf dem Datenträger befinden. Falls ein Fehler aufgetreten ist, sollte die Optimierung anschließend nicht gestartet werden. Auch falls ein nachträgliches *scannen* des Laufwerks keine Fehler ausgibt, ist von einer Optimierung abzuraten.




## 1.4 Scan 

Vor der Optimierung muß das Laufwerk immer zuerst *gescannt* werden. `Scan` analysiert und speichert die komplette Verzeichnisstruktur Ihres Datenträgers, und kann nach der erfolgreichen Verarbeitung dieser Informationen dem Benutzer genau mitteilen, wie stark die auf dem Datenträger befindlichen Dateien fragmentiert sind.

Während dem *Scannvorgang* werden keine Daten geschrieben. `Scan` kann also getrost auf alle möglichen Festplattenpartitionen oder Disketten losgelassen werden, um den Grad der Verwüstung anzuzeigen.

Nach einem Druck auf `Scan` werden wie bei "Prüfen" fast alle Knöpfe mit einem Schwarzschleier überzogen. Die Statusanzeige wechselt um in "Scannen", und die Trackanzeige oben links zeigt nun dunkle und helle Punkte oder Striche an (Alle Farbangaben beziehen sich auf die Standardfarben einer Workbench 2.x). Jeder dieser Farbkleckser ist ein Block auf dem Datenträger. Ein heller Klecks ist ein Infoblock, der nur zur Verwaltung der Daten vorhanden ist. Ein dunkler Klecks ist ein Datenblock.

Der *Scannvorgang* kann jederzeit mit `Stop` abgebrochen werden.

Je nach dem wie diese Farben in der Trackanzeige verteilt sind, fällt auch dann das Scan-Ergebnis aus, das nach dem *Scannvorgang* erscheint.

Zwei Werte werden hier ausgegeben, von denen der erste der wichtigere ist. Dieser Wert gibt die Anzahl der Dateien in Prozent an, die mindestens in zwei Teile zerteilt sind. Sind also zum Beispiel 20% fragmentiert, ist durchschnittlich jede fünfte Datei in ein oder mehrere Teile zerstückelt!

Die Anzeige der "fragmentierten Infos" ist mehr für die wirklichen CLI-Freaks gedacht. Desto kleiner dieser Wert, desto schneller können Verzeichnisse vom CLI aus angezeigt werden. Da die Workbench zusätzlich zu den Verzeichnissen noch Icons mitspeichert, und diese dann beim Lesen einlädt, gibt es hierfür eine andere Optimierungsart.

Das Fenster mit dem *Scan-Ergebnis* kann durch einen Klick auf `OK!` verlassen werden.


### 1.4.1 Laufwerk freigeben 

TOP! geht nach dem erfolgreichen *scannen* eines Datenträgers davon aus, daß dieses Laufwerk danach optimiert wird. Da TOP! sichergehen will, daß keine Informationen auf dem Datenträger geändert werden, bleibt das Laufwerk in den Händen von TOP!.

Um auf das Laufwerk in diesem Fall wieder zuzugreifen, ist ein Klick auf `Laufw. freig.` nötig.

Wenn eine Optimierung ohne vorherigem Scannen gestartet wird, wird Scan automatisch durchgeführt.




## 1.5 Optimieren 

Kommen wir nun zum Hauptpunkt von TOP!. Das Optimieren. Bevor aber der Hauptgang gestartet wird, sollten folgende Parameter noch überprüft, beziehungsweise verändert werden.


### 1.5.1 WB-Modus 

Der `WB-Modus` sollte bei einer intensiven Nutzung der Workbench eingestellt werden.

In diesem speziellen Optimierungsmodus werden die Icons, die auf der Workbench plaziert sind zwischen die Informationsblöcke gelegt. Es entsteht dadurch bei der Benutzung der Workbench ein merkbarer Geschwindigkeitsvorteil beim Öffnen von Verzeichnissen.


### 1.5.2 CLI-Modus 

Falls hauptsächlich mit dem *CLI* gearbeitet wird, ist eine Optimierung mit dem `CLI-Modus` wohl am besten geeignet. Hier werden einfach nur die Informationsblöcke aneinandergereiht, um das möglichst schnelle Lesen eines Verzeichnisses zu verschnellern.


### 1.5.3 ReadBuff 

Hier kann optional ein zusätzlicher Trackbuffer beim Lesen eingestellt werden. Je nach Laufwerk und Fragmentierung können sich durch das Einschalten von `ReadBuff` erhebliche Geschwindigkeitsvorteile ergeben.


### 1.5.4 Gfx-Anzeige 

Da der Aufbau der linken oberen Trackanzeige beim Optimieren relativ Aufwendig ist, und teilweise auf langsameren Prozessoren in der *Optimierungszeit* bemerkbar wird, kann sie hier ausgeschaltet werden.


### 1.5.5 Verbrauch 

Hier kann der ungefähre Speicherverbrauch von TOP! mit den Pfeiltasten eingestellt werden. Ist der links neben den Tasten befindliche Bereich aufgefüllt, wird fast der gesamte Speicher für die Zwischenspeicherung der Datenblöcke hergenommen. Ist er leer, wird so wenig wie nötig verwendet.

Die Anzahl der freien Bytes im Hauptspeicher kann jederzeit rechts unten unter "Bytes frei" abgelesen werden.



### 1.5.6 Start 

Nach den oben beschriebenen Einstellung kann nun die Optimierung begonnen werden. Falls vorher noch nicht gescannt wurde, oder vielleicht einige wichtige Parameter geändert wurden, wird der *Scannvorgang* nochmals gestartet. Wobei diesmal kein Scan-Ergebnis mehr ausgegeben wird. Auch ist nun eine Unterbrechung nicht mehr möglich!

Bitte vergewissern Sie sich vorher, daß Sie sich eine *Sicherheitskopie* von den wichtigsten Daten angelegt haben!

Bitte beachten Sie auch, daß nicht schon optimierte Datenträger optimiert werden, da sich dadurch systembedingt größere interne Berechnungszeiten beim Status "Bewegen" ergeben können!

Nach dem Scannen des Datenträgers führt die Optimierung noch einige interne Tests durch, und beginnt dann mit dem Kopieren der Daten. Zuerst werden Daten an beliebigen Positionen in den Speicher gelesen (hell dargestellt), und dann wieder zurückgespeichert (in blau dargestellt). Dieser Vorgang wiederholt sich solange, bis keine Datenblöcke mehr vorhanden sind. Die Geschwindigkeit ist abhängig von der Anzahl der Datenblöcke, von der Geschwindigkeit Ihres Laufwerkes sowie die Menge des Speichers, die dem Programm zum Verschieben der Daten zur Verfügung gestellt wurde.

Bitte beachten Sie, daß bei einer Unterbrechung während der Optimierung durch z.B. Ausschalten des Computers wichtige Daten verloren gehen können!




## 1.6 TOP! beenden 

Das Programm kann entweder durch einen Druck auf den Schließknopf links oben am Fenster beendet werden, oder durch einen Druck auf den `Ende` Knopf.




### Anhang A Statusanzeige 


Die Statusanzeige kann folgende Aktionen anzeigen:

warte...

-  Hier wird auf eine Eingabe des Benutzers gewartet 

Prüfen

-  Momentan wird ein Datenträger überprüft 

Scannen

-  Der Scannvorgang ist in Aktion 

Korrigieren

-  Die gescannten Blöcke werden im Speicher korrigiert 

Sortieren

-  Die gescannten Blöcke werden im Speicher sortiert 

LRTest

-  Aus Geschwindigkeitsgründen wird hier überprüft, wierum ein Datenträger optimiert werden soll. 

Bewegen

-  Diese Funktion findet heraus, welche Blöcke im nächsten Verschiebevorgang bearbeitet werden müssen. Teilweise kann diese Funktion relativ viel Zeit in Anspruch nehmen. 

Lesen

-  Nun werden die Daten eingelesen 

Koordinieren

-  Die Zeiger aller eingelesenen Informationsblöcke werden korrigiert. 

Schreiben

-  Die Daten werden wieder zurückgeschrieben. 




## Anhang B Tastaturkürzel 

Im Fenster von TOP! sind die meisten Funktionen durch die folgenden Tastaturkürzel auswählbar:

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

Aktionsknöpfe

`p`	Prüfen  
`s`	Scan  
`s`	Stop...  
`o`	Optimieren...  
`ü`	Über...  
`e`	Ende

Verschiedene Hinweisfenster:

`v`	Bestätigung (linker Knopf)  
`b`	Abbruch (rechter Knopf)




## Anhang C Fehlermeldungen beim Datenzugriff 


Folgende Fehler können beim Lesen oder Schreiben von Daten vorkommen:

Kein Sektor-Header  
Falsche Sektor-Preamble  
Falsche Sektor-ID  
Falsche Header-Prüfsumme  
Falsche Sektor-Prüfsumme  
Zu wenige Sektoren  
Falscher Sektor-Header

-  Alle diese Fehlermeldungen deuten darauf hin, daß ein Sektor beziehungsweise eine Spur defekt ist. 

Schreibgeschützt

-  Der Datenträger ist schreibgeschützt. 

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

