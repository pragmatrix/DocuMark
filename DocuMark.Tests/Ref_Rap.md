RAP! Inhaltsverzeichnis

Einf�hrung

1	Grundprinzip  
1.1	hierarchisches Dateiverwaltungssystem

2	Das Konfigurationsprogramm  
2.1	Einstieg: Beispiel mit der RAM Disk.  
2.2	Pfadeinstellungen  
2.3	Globale Pfadeinstellungen, Blockfunktionen  
2.4	Aktualisierung  
2.5	Packer  
2.6	Crypter, Passwort  
2.7	ChunkGr��e, OvlGr��e  
2.8	VolPr�fix, VolSuffix  
2.9	HandlerDatei, HandlerStack

3	RAP! bei der Arbeit  
3.1	Was sollte man nicht komprimieren.  
3.1.1	Datenbankdateien  
3.1.2	Disk-Dateien  
3.1.3	komprimierte Dateien  
3.1.4	Systemdateien  
3.1.5	wichtige Daten  
3.2	komprimierte Dateien verarbeiten.  
3.3	Installationen �bertragen.  
3.4	Workbench-Benutzung.

Anhang A	Defaultwerte der globalen Einstellungen  
Anhang B	Aufbau der Konfigurationsdatei  
Anhang C	Fehlermeldungen bei der Verarbeitung der Konfigurationsdatei  
Anhang D	RAP-Mount  
Anhang E	XPK-Standard  
Anhang F	Platzhalter  
Anhang G	Die mitgelieferten Packer "scn1" und "runl".  
Anhang H	Tastaturk�rzel im Konfigurationsprogramm.



# Einf�hrung 

Durch st�ndig steigende Rechnergeschwindigkeit und immer effizienteren Algorithmen geh�rt das Komprimieren von Daten in der Computerwelt zur Allt�glichkeit. Auch auf dem Amiga haben diese Datenkomprimierer vor einigen Jahren den Einzug gehalten.

�blich sind die Archivierer. Die teilweise umst�ndlich vom AmigaDOS aus aufgerufen werden, um dann mit meistens langen Wartezeiten gesamte Verzeichnisse zu packen. Der Sinn hierin besteht wie der Name schon sagt haupts�chlich in der Archivierung der Daten.

Einige andersdenkende Programmierer sind nun auf die Idee gekommen, komplette Programme zu packen, um sie dann beim Start zu entkomprimieren. Da aber der Programmteil, der die Daten entkomprimiert, vom Betriebssystem aufgerufen werden mu�, kann nur das Hauptprogramm - die Datei, die auch wirklich aufgerufen wird - komprimiert werden. Meistens macht das bei gr��eren Anwendungen wenig Sinn. Bei diesem Verfahren spricht man hier auch vom *Echtzeit-dekomprimieren*, da auf schnelleren Rechnern kaum ein Zeitverlust beim Laden der Datei bemerkbar ist.

Die beiden oben geschilderten Verfahren sind die momentan noch am gebr�uchlichsten. RAP! ist der erste professionelle Versuch auf dem Amiga ein anderes, neuartiges System einzuf�hren, das dem Benutzer den Komprimier- und Entkomprimier-Vorgang unsichtbar abnimmt. Durch dieses Verfahren ist es nun auch m�glich reine Daten zu komprimieren und in Echtzeit (beim Laden) zu entkomprimieren, was mit den oben geschilderten Verfahren nur umst�ndlich (programmgesteuert) realisierbar gewesen w�ren.

Im Gegensatz zu den beiden anderen Verfahren ver�ndert RAP! nach au�en hin keine Dateien. RAP! bildet eine Schnittstelle zwischen dem Benutzer (den Programmen) und dem Datentr�ger. Werden nun vom Benutzer Daten auf den Tr�ger geschrieben, schaltet sich RAP! dazwischen, komprimiert die Daten unsichtbar, und l��t dem Benutzer zum Beispiel im Glauben, da� die Datei doch jederzeit in der Originall�nge vorliegt. Genauso ist das Verhalten beim Laden. Unsichtbar, egal, ob Daten in einem Texteditor eingeladen, oder irgendwelche Programme gestartet werden. Nicht einmal das Betriebssystem bekommt etwas davon mit, da� die Daten gepackt wurden. Auch der Benutzer wird zumindest beim entkomprimieren von Daten keinen wesentlichen Unterschied bemerken.




# 1 Grundprinzip 

Da bei Computerprogrammen (zumindest auf dem Amiga) FLEXIBILIT�T gro� geschrieben wird, wurde zur Erweiterung des Datenkomprimierers noch einige Zusatzfunktionen integriert, die nachfolgend erkl�rt werden sollen.




## 1.1 hierarchisches Dateiverwaltungssystem 

Mit RAP! ist es nicht nur m�glich eine gesamte Diskette oder Festplattenpartition zu komprimieren, sondern RAP! arbeitet auch Verzeichnis-, beziehungsweise Datei-orientiert. Mit dem *hierarchischen Dateiverwaltungssystem* kann f�r jedes Verzeichnis. Ja sogar f�r jede Datei der Komprimierer und einige andere Parameter eingestellt werden.

Wichtig ist in diesem Zusammenhang zu wissen, da� diese vom Benutzer mit Hilfe des Konfigurationsprogramms eingegebene Verzeichnisstruktur nicht transparent zu der wirklich vorhandenen Struktur ist. Es k�nnen also irgendwelche Parameter f�r ein Verzeichnis eingestellt werden, obwohl dieses Verzeichnis momentan noch nicht vorhanden ist. Besonders bei der Verwendung zusammen mit *entfernbaren Datentr�ger* (Disketten) bringt dieses System Vorteile. Der FileHandler von RAP! �berpr�ft bei jeder Neuerstellung einer Datei die eingestellten Parameter und handelt dann dementsprechend.

Ein weiterer Vorteil ist nat�rlich auch die Anwendung von sogenannten spezialisierten Packern, oder ganz einfach das Ausschalten des Packers. Es w�re Unsinn ein Verzeichnis zu komprimieren, in dem sich sowieso nur gepackte Archive befinden. Dies kostet nur Zeit, und verursacht sogar in Ausnahmef�llen, da� die Dateien intern l�nger werden.

(technische Anmerkung:  Die Daten werden im unkomprimierten Format gespeichert, aber durch spezielle Verkettungsstrukturen kann die Datei trotzdem l�nger werden)

Durch diese Hierarchie erlaubt RAP! Ihnen zus�tzlich auch eine *Passwortvergabe*. Es ist m�glich f�r jedes Verzeichnis ein anderes Passwort zu vergeben, so da� nun auch mehrere Anwender eines Rechners Ihre privaten Daten vor Zugriffe sch�tzen k�nnen. Aus technischen Gr�nden ist die Dateienstruktur nach au�en hin auch bei noch nicht eingegebenem Passwort sichtbar. Nur das Starten oder Verarbeiten der Daten ist nicht m�glich. Unter der Amiga-Workbench ergibt sich dadurch ein netter Effekt: die Icons, die f�r Workbench-Programme notwendig sind (.info-Dateien) werden kodiert, und sind somit nicht mehr von der Workbench aus sichtbar.

Durch die Kodierung der Icons kann dann beim �ffnen eines Verzeichnisses auf der Workbench schon eine l�stige *Passwortabfrage* erscheinen. Der FileHandler des RAP!-systems versucht lediglich das Icon zu dekodieren.




# 2 Das Konfigurationsprogramm 

Wie bei anderen Programmen ben�tigt auch RAP! bestimmte Parameter, die vom Anwender eingestellt werden m�ssen. Um die Eingabe m�glichst einfach zu gestalten, wurde ein Programm entwickelt, das sich in das Konzept der OS2.x Konfigurationsprogramme einreiht.




## 2.1 Einstieg: Beispiel mit der Ram Disk. 

Nach einer erfolgreichen Installation ist der erste Schritt der Aufruf des Konfigurationsprogramms, das sich im "Prefs"-verzeichnis des Datentr�gers befindet, auf dem RAP! installiert wurde. Um das Konfiguration zu starten, mu� das Icon mit einem Doppelklick angew�hlt werden.

Wenige Sekunden danach erscheint die Oberfl�che von RAPPrefs, *das Basisfenster*, welches horizontal in zwei Bereiche gegliedert ist. Links ein Anzeigebereich, in dem die *Laufwerkseinstellungen* sowie die *Pfadeinstellungen* dargestellt werden, und rechts die Aktionskn�pfe, die wiederum in Unterabschnitten unterteilt sind. Nach einer erfolgreichen Installation sollte in dem linken Anzeigebereich nur ein *GLOBAL:* sichtbar sein.

Um nun in die *globalen Laufwerkseinstellungen* zu gelangen, mu� `GLOBAL:` mit einem Doppelklick oder einem Klick mit der anschlie�enden Auswahl von `Editieren` angew�hlt werden. Von den *globalen Laufwerkseinstellungen* werden die Einstellungen, die in den *Laufwerkseinstellungen* beziehungsweise *Pfadeinstellungen* nicht gemacht werden, �bernommen. Werden in den globalen Einstellungen Parameter nicht gesetzt, werden sie von den intern fest gespeicherten *Default-Werten* (siehe Anhang A) �bernommen.

Wir wollen hier die Werte nicht ver�ndern, und stellen nur zum Test einen Packer ein. Klicken Sie hierzu einmal auf den *Vererbungsknopf* (rechts neben dem Text "Packer"), um die Einstellung des Packers zu erm�glichen (der Knopf mit den 2 gef�llten und einem ungef�llten Rechteck). Nun klicken Sie nun noch in die Listenanzeige auf den nach einer erfolgreichen Installation vorhandenen "scn1"-Packer, um Ihn anzuw�hlen. Wenn Sie jetzt noch den links unten befindliche OK-Knopf dr�cken, ist der Packer *global* gesetzt.

Wir befinden uns wieder im *Basisfenster*, das bis jetzt noch keine Ver�nderung erfahren hat. Der Packer wurde zwar schon eingestellt, aber es fehlt noch eine wichtige Information, um das Packen der Dateien zu erlauben. Dem Programm mu� noch mitgeteilt werden, f�r welches Laufwerk die eingestellten Parameter �berhaupt gelten sollen. Da die Ram Disk meistens vorhanden ist, werden wir dem Konfigurationsprogramm mitteilen, da� zu Testzwecken zuerst "RAM:" verwendet werden soll.

W�hlen Sie hierf�r den Knopf `Anf�gen/Laufwerk` an, um die *Laufwerkseinstellungen* aufzurufen. Sofort wird eine �hnlichkeit zu den globalen Einstellungen erkennbar. Einige Parameter k�nnen hier neu eingestellt werden, beziehungsweise auf ein bestimmtes Laufwerk *lokalisiert* werden. Momentan werden aber nur die Einstellungen *SYS-Laufwerk* und *RAP-Laufwerk* ben�tigt. W�hlen Sie bei *SYS-Laufwerk* `RAM:` an, und geben Sie bei *RAP-Laufwerk* zum Beispiel ein `RAP:` an. Der *RAP-Laufwerksname* ist beliebig w�hlbar, darf aber nicht schon einmal verwendet worden sein.

Nun wird "RAP:" zur neuen "RAM:" erkl�rt. Der Doppelpunkt ist bei beiden Einstellungen optional. Nachdem wieder wie vorher auf den OK!-knopf geklickt wurde, befinden wir uns wieder im *Basisfenster*.

Jetzt ist hier eine �nderung erkennbar. Unter dem `GLOBAL:` m��te eine *Laufwerkszuweisung* `RAM:  -> RAP:` sichtbar werden. Die *Laufwerkszuweisungen* stehen immer in der ersten Spalte und haben ein "->" zwischen den *Laufwerksnamen*. Sp�ter k�nnen hier noch Pfade angef�gt werden.

Um das Programm zu verlassen und die Einstellung auszuprobieren, kann nun im *Basisfenster* auf `Sichern` oder `Verwenden` geklickt werden. Beachten Sie bitte, da� falls beim `Sichern` automatisch die vorhandenen Einstellungen beim n�chsten *Bootvorgang* ausgef�hrt werden, beziehungsweise die *RAP-Laufwerke* aktiv werden.

Nun sollte in den n�chsten Sekunden auf Ihrer Workbench zus�tzlich zu den sonst vorhandenen Laufwerk-Icons noch ein Icon erscheinen, das den Namen der Ram Disk mit einem anf�hrenden "_" tr�gt. Es bifinden sich nun auf der Workbench sozusagen zwei Ram Disks. In Wirklichkeit sind die darin abgelegten Daten die selben. Nur die Kommunikation geht verschiedene Wege. Probieren wir es aus. Nehmen Sie ein Icon eines beliebigen Programms und ziehen Sie es auf das Ram-Icon ohne dem "_". Die Datei wird in die Ram Disk kopiert (Achten Sie bitte m�glichst auf den freien Speicher). Wenn nun auf die "Ram Disk" doppelgeklickt wird, wird dasselbe Programm in dem Fenster des anderen *Laufwerks* erkennbar. Bei einem Doppelklick auf die Ram_Disk mit "_" erscheint ein Fenster mit dem selben Inhalt. Das Programm befindet sich zweimal in der Ram Disk. Wie vorher aber schon gesagt sind die Daten die selben. Es wird also kein zus�tzlicher Speicher ben�tigt.

So, nun machen wir das Ganze mit Hilfe der Discard oder Delete-Funktion der Workbench wieder r�ckg�ngig, und probieren den zweiten Weg aus: L�schen Sie also nun die Datei aus dem Speicher (Sie k�nnen hierf�r eine der beiden Ram_Disks hernehmen), schlie�en die Fenster und kopieren Sie die Datei wieder durch Her�berziehen des Icons. Nicht aber wie im vorigen Beispiel in die *normale* Ram_Disk sondern in die neu angelegte. Nach einem bemerkbaren Zeitverlust beendet sich der Kopiervorgang. Es funktioniert also wie oben beschrieben, nur mit dem Unterschied, da� einfach ein anderes Laufwerk hergenommen wurde.

Sehen wir nach, was sich getan hat, indem wir die beiden Fenster der Ram Disk durch Doppelklicken �ffnen. Sofort wird erkennbar, da� das *kopierte* Programm nicht mehr in beiden Fenstern sichtbar ist. Nur noch in der "_Ram Disk". Dies ist durch den Umstand zu erkl�ren, da� das Icon gepackt wurde, und somit nur in der Ram Disk sichtbar ist, die vom RAP!-System kontrolliert wird. Hier wird in *Echtzeit* das Icon dekomprimiert und dargestellt. Die Dateien sind im �brigen auch in beiden Ram Disks vorhanden, nur sind sie in der einen ohne "_", die nicht vom *RAP!-System* kontrolliert wird, gepackt abgelegt, und somit f�r den Anwender fast unbrauchbar. Ausnahme ist das zum Beispiel m�gliche Kopieren auf einen anderen mit RAP! versehenen Datentr�ger (auch per *DF�*!), um sich das Entkomprimieren und Rekomprimieren zu ersparen.

Nat�rlich kann jetzt nicht nur das Icon angezeigt werden, sondern auch das Programm wie gewohnt gestartet werden. Es nimmt weniger Platz auf der Ram-Disk ein, und wird beim Doppelklicken in Echtzeit dekomprimiert und gestartet. Wobei die Dekomprimierung hier wirklich fast immer unmerkbar abl�uft.

Vielleicht alles am Anfang etwas schwierig zu verstehen. Aber nach einer kleineren Einarbeitungszeit kommt man schon dahinter, wie man was in welches Verzeichnis kopieren, l�schen oder bewegen soll, damit es komprimiert oder dekomprimiert wird.

Komplizierter wird es bei den Pfadeinstellungen, die im n�chsten Kapitel eingef�hrt werden.




## 2.2 Pfadeinstellungen 

Zus�tzlich zu den *Laufwerkseinstellungen* kann nun auch f�r jeden Pfad oder Datei eines Laufwerks Parameter eingestellt werden. Stellen wir uns vor, da� sich zum Beispiel ein Verzeichnis auf Ihrer Festplatte mit dem Namen "arc" befindet, das nur archivierte Dateien enth�lt. Nat�rlich ist es nicht sinnvoll dieses Verzeichnis auch noch zu komprimieren, da es ja schon komprimierte Dateien enth�lt.

Probieren wir es wie im letzten Kapitel beschrieben mit der Ram Disk aus: Falls die *Laufwerkszuweisung* ("RAM:  -> RAP:") nicht schon aktiviert (invertiert) ist, mu� sie durch einen Klick angew�hlt werden, um dem Konfigurationsprogramm mitzuteilen, da� noch Informationen zu diesem Laufwerk anf�gt werden.

Durch einen Klick auf den Knopf `Anf�gen/Pfad` oder `p`, werden die *Pfadeinstellungen* aufgerufen. Auch hier �hnelt der Bildschirmaufbau dem der *Laufwerkseinstellungen*. Es gibt zwei Arten von *Pfadeinstellungen*: *Exclude und Include*. Ein *Exclude-Pfad* ist ein Pfad, der nicht bearbeitet wird. Er wird also auch zum Beispiel bei einem Zugriff auf das *RAP-Laufwerk* nicht komprimiert, obwohl entsprechende Parameter eingestellt wurden. Da wir das Verzeichnis "arc" sp�ter nicht bearbeiten (nicht komprimieren) wollen, m�ssen diese Pfadeinstellung auf `Exclude` gestellt werden. Dies geschieht, indem das sogenannte Cycle-Gadget gedr�ckt wird. Die Anzeige sollte nun von `Include` auf `Exclude` wechseln.

Nun fehlt uns noch die *Verzeichnisauswahl*. Das Konfigurationsprogramm mu� wissen, welches Verzeichnis es *excluden* mu�. Diese Auswahl kann entweder durch einen Druck auf `Lesen` und einer anschlie�endem Auswahl durch einen Mausklick in der darunterliegenden Listenanzeige geschehen, oder durch Direkteingabe des Verzeichnisses im Eingabefeld unter der Listenanzeige. Hier k�nnen auch die im Anhang F beschriebenen Platzhalter verwendet werden.

Falls das Verzeichnis "arc" in der Ram Disk schon erstellt wurde, kann nun mit `Lesen` die Verzeichnisse im Listenfenster angezeigt und augew�hlt werden. Falls das Verzeichnis noch nicht vorhanden ist, mu� per Hand "arc" in das Eingabefeld unter der Listenanzeige eingegeben werden.

Klicken Sie nun auf `OK!` um wieder in das *Basisfenster* zur�ckzukommen. Auf dem Bildschirm m��te nun folgendes Sichtbar sein:

	
	GLOBAL:        (dunkel oder normal)
	RAM: -> RAP:   (dunkel oder normal)
	  >arc         (hell oder kursiv)
	

Wie Sie vielleicht sofort bemerkt haben, wird das `>arc` hell (oder auf einer *2-farben Workbench* kursiv) dargestellt. Hell ist ein Hinweis darauf, da� diese *Pfadeinstellung* *excluded* ist, also der Pfad arc in der Ram Disk nicht bearbeitet wird.

Mit Hilfe der Funktion `Anf�gen/Unterpfad` kann nun auch zum Beispiel ein Unterverzeichnis von "arc" wieder bearbeitet werden. Stellen wir uns vor, da� sich zwar im "arc"-verzeichnis nur komprimierte Dateien befinden, aber ab und zu mal eine komprimierte Datei in das Verzeichnis "arc/unarc" entkomprimiert wird, um die Daten zu anschlie�end andersweitig zu verarbeiten. In diesem Fall w�re es sicherlich sinnvoll, das Unterverzeichnis "unarc" wieder zu komprimieren, da sich darin nur unkomprimierte Daten befinden.

W�hlen Sie also `>arc` durch einen einfachen Klick an, und dr�cken auf den Knopf `Anf�gen/Unterpfad` oder `u` um die *Pfadeinstellungen* f�r einen Unterpfad anzuf�gen.

Nun befinden befinden wir uns wieder in den *Pfadeinstellungen*. Hier lassen Sie alles wie gehabt, und geben im Eingabefeld links unten den Pfad "unarc" ein. Falls das Verzeichnis schon existiert kann hier die Auswahl durch einem Druck auf `Lesen` vereinfacht werden.

Nun wieder `OK!` um in das Basisfenster zu gelangen. Die Listenanzeige sollte nun folgenderma�en aussehen:

	
	GLOBAL:        (dunkel oder normal)
	RAM: -> RAP:   (dunkel oder normal)
	  >arc         (hell oder kursiv)
	    >unarc     (dunkel oder normal)
	

Wie Sie schon sehen k�nnen ist durch die Angabe von `Anf�gen/Unterpfad` "unarc" in eine andere Ebene gerutscht. "unarc" ist weiter rechts von "arc" plaziert, was soviel bedeutet, da� auch in der Dateienstruktur dieses Verzeichnis eine Ebene weiter unten liegt.




## 2.3 Globale Pfadeinstellungen, Blockfunktionen 

Manchmal ist es notwendig, da� bestimmte Pfadeinstellungen auf jedem Datentr�ger eingestellt werden sollen, die auf jeden durch RAP! angesprochenen Datentr�ger gemacht werden sollten. Sollen zum Beispiel mehrere Festplatten oder Disketten, auf denen sich je ein "arc"-verzeichnis befindet, das nicht gepackt werden soll, bearbeitet werden, ist es zwar mit den *Blockfunktionen* m�glich die Parameter an ein anderes Laufwerk anzuf�gen, w�rde aber nach einiger Zeit ziemlich irritierend werden. Um nun eine *globale Pfadeinstellung* vorzunehmen, klicken Sie beim `Anf�gen/Pfad` nicht vorher auf ein Laufwerk in der *Listenanzeige*, sondern auf `GLOBAL:`. Falls noch das Beispiel im vorherigen Kapitel eingestellt ist, k�nnen hier auch gleich die *Blockfunktionen* ausprobiert werden:

Klicken Sie `>arc` an, und gehen auf die Blockfunktion `Ausschneiden` rechts unten, oder dr�cken Sie `c`. Schon ist der Pfad `>arc` und wie vielleicht nicht voraussehbar auch der Pfad `>unarc` verschwunden. Beim Ausschneiden werden aus rein logischen Gr�nden auch die gesamten Unterpfade des Laufwerks oder des Pfades ausgeschnitten. Diese Daten befinden sich nun in einem unsichtbaren Zwischenspeicher, der mit `Block/Anf�gen` und `Block/Unter-Anf�gen` an eine andere Stelle im *Listenfenster* wieder angef�gt werden kann.

Klicken Sie nun auf `GLOBAL:`, da wir Pfade an die *globalen Einstellungen* anf�gen wollen, und dann auf `Block/Anf�gen`. Folgendes Bild sollte sich ergeben:

	
	GLOBAL:        (dunkel oder normal)
	  >arc         (hell oder kursiv)
	    >unarc     (dunkel oder normal)
	RAM: -> RAP:   (dunkel oder normal)
	

Falls nun in Zukunft noch mehrere Laufwerke angef�gt werden (dies geschieht zum Beispiel mit einem Klick auf `RAM:  -> RAP:` und `Anf�gen/Laufwerk`), werden wie die *globalen Laufwerkseinstellungen* (Doppelklick auf `GLOBAL:`) f�r jedes Laufwerk immer die *globalen Pfadeinstellungen* *vererbt*.

Die vererbten Parameter k�nnen durch die Angabe neuer Parameter in den *Laufwerkseinstellungen* und *Pfadeinstellungen* ge�ndert werden. Die *Vererbung* wird dann aber in die weiter unteren liegenden Ebenen �bertragen. Ein kleines Beispiel mit dem Packer:

	
	GLOBAL:        (dunkel oder normal) (Packer: scn1)
	RAM: -> RAP:   (dunkel oder normal) (Packer nicht gesetzt)
	  >verz1       (dunkel oder normal) (Packer: scnx)
	    >verz2     (dunkel oder normal) (Packer nicht gesetzt)
	

Global ist die oberste Ebene in der der Packer "scn1" gesetzt wurde. In der *Laufwerkszuweisung* eine Zeile darunter wird kein Packer gesetzt, also der Packer aus einer Ebene dr�ber verwendet (scn1). Das Verzeichnis 1 unterbricht diese Vererbung, und setzt f�r sich und f�r das Verzeichnis 2, das ja eine Ebene unter Verzeichnis 1 liegt, einen anderen Packer (scnx). Folgende Parameter sind also nun f�r die einzelnen Einstellungen g�ltig:

	
	GLOBAL:        (dunkel oder normal) (Packer: scn1)
	RAM: -> RAP:   (dunkel oder normal) (Packer: scn1 / wurde vererbt)
	  >verz1       (dunkel oder normal) (Packer: scnx)
	    >verz2     (dunkel oder normal) (Packer: scnx / wurde vererbt)
	

Diese Beispiele sollen einigerma�en die *Vererbungslogik* verdeutlichen. Nat�rlich richten sich auch alle anderen einstellbaren Parameter nach diesem System.




## 2.4 Aktualisierung 

Falls nun alle gew�nschten Parameter im Konfigurationsprogramm eingestellt wurden, ist der Schritt vor dem Abspeichern der Konfiguration noch die *Aktualisierung*. Je nach dem, was momentan gerade in der *Listenanzeige* im *Basisfenster* ausgew�hlt ist, k�nnen Unterverzeichnisse oder gesamte Laufwerke aktualisiert werden. In der Aktualisierung werden alle Daten auf den neusten Stand gebracht. Wenn zum Beispiel in irgendeinem Verzeichnis der Packer oder das Passwort ge�ndert wurde, erkennt die Aktualisierung das vollkommen automatisch und packt oder verschl�sselt die Daten neu.

Da wie schon vorher berichtet die Verzeichnisstruktur im Konfigurationsprogramm nicht mit der aktuell auf dem Datentr�ger vorhandenen Struktur gleich sein mu�, kann beim Anklicken auf `Aktualisieren` ein Hinweisfenster erscheinen, das Sie bittet, doch ein �bergeordnetes Verzeichnis zu aktualisieren.

Falls das *Aktualisieren-Fenster* erscheint, kann mit Hilfe des `Start` Knopfes die Aktualisierung begonnen werden. In der dar�ber liegenden Anzeige werden die Dateien angezeigt, die aktualisiert werden. Mit Hilfe von `Alles anzeigen` k�nnen auch die Dateien angezeigt werden, die zwar gefunden wurden, aber nicht bearbeitet werden.

Beim Start wechselt der `Start` Knopf in ein `Pause` Knopf, der bei Bet�tigung die Aktualisierung unterbricht und sich in einen `Weiter` Knopf verwandelt. Nach Druck auf `Weiter` wird die Aktualisierung fortgesetzt.

Die verschiedenen Dateien werden je nach Bearbeitungsmodus in folgenden Farben dargestellt:

	Normal	Alles anzeigen

Datei aktualisiert	dunkel	Farbe 3 (blau)  
Datei Exclude/nicht aktualisiert	keine Anzeige	hell  
Datei Include/nicht aktualisiert	keine Anzeige	dunkel

Die Aktualisierung kann jederzeit mit `Abbruch` beendet werden.

Bitte beachten Sie, da� vor der Aktualisierung noch gen�gend *Speicherplatz* vorhanden ist. Wenn nicht gen�gend Speicher vorhanden ist, kann es vorkommen, da� die Daten zum Beispiel nicht komprimiert werden!




## 2.5 Packer 

In in jeder Art der Einstellungsfenster (*globale Laufwerkseinstellungen*, *Laufwerkseinstellungen* und *Pfadeinstellungen*) ist die Vergabe eines Packers m�glich. Vererbt werden die Einstellungen des �bergeordneten Eintrages dann, wenn der *Vererbungsknopf* rechts oben �ber der *Listenanzeige* keine Verbindungen zwischen den drei Rechtecken aufweist, und die Listenanzeige nicht in Geisterschrift angezeigt wird (�berzogen mit einem schwarzem Pixel-Muster).

Die Anzahl und das Vorhandensein der Packer kann variieren. Es werden die *RAP!-Packer* anerkannt die sich auf Ihrem *Bootmedium* im Verzeichnis `Libs:pack` befinden. Momentan nur "scn1" und "runl". Mit Hilfe der PD-Ver�ffentlichung des *XPK-Standards* k�nnen weitere Packer eingebunden werden, die sich dann im `Libs:compressors` Verzeichnis befinden. Die Anzeige der *XPK-Packer* geschieht automatisch. Die *RAP!-packer* werden in kleiner Schrift dargestellt, die *XPK-Packer* in Gro�schrift. Da sich noch in der alten Version der *XPK-Library* ein Fehler befand, der die Verwendung f�r RAP! ausschlo�, ist die Verwendung von *XPK-Packer* erst ab der `xpkmaster.library` Version 2 m�glich.

Die Ausschaltung des Packers geschieht durch das einfache L�schen der 4 Packer-Buchstaben unter der Listenanzeige liegendem Eingabefeld. In diesem Fall mu� die Vererbung ausgeschaltet sein.




## 2.6 Crypter, Passwort 

Auch wie die oben geschilderte Packer-Einstellung kann in jeder Einstellungsart ein Crypter sowie ein Passwort eingestellt werden: Mit Hilfe des Passwortes k�nnen Daten vor fremden Zugriff gesch�tzt werden. Auch hier gelten die �blichen *Vererbungsregeln*, die schon ausreichend erkl�rt wurden.

Bis jetzt werden nur die *RAP!-Crypter* unterst�tzt. Einer befindet sich nach der erfolgreichen Installation im Verzeichnis `Libs:crypt`, der den Namen "fast" tr�gt. Wie der Name schon sagt, ist er relativ schnell, und sollte keine Zeitverz�gerungen aufweisen.

Die Einstellung geschieht genauso wie bei den Packer. Das L�schen auch durch das L�schen der 4 Buchstaben im Eingabefeld unter der Listenanzeige. Zus�tzlich zu dieser Einstellung ben�tigen wir nun auch ein Passwort. Dieses Passwort wird mit Hilfe des Knopfes `Neu` ver�ndert. Falls ein Crypter gesetzt wurde, erscheint nun ein Fenster, worin das Passwort eingegeben werden kann. Falls zuvor ein Passwort schon gesetzt war, wird es auch in diesem Fenster abgefragt. Nach erfolgreicher Eingabe wird das Passwort einmalig links neben dem `Neu` in der Anzeige dargestellt. Bitte merken Sie sich nun das Passwort, denn es wird nie wieder erscheinen. Aus Sicherheitsgr�nden wird das Passwort nicht gespeichert, sondern nur ein Pr�fsumme, aus der lediglich die Richtigkeit eines Passwortes hergeleitet wird, nicht aber der genaue Name.

Es ist nicht wieder m�glich das Passwort herauszufinden. Bitte achten Sie genau darauf, welche Zeichen Sie eingeben.

Im sp�teren Betrieb wird nach jedem Neustart des Rechners bei einem Zugriff auf eine kodierte Datei ein Passwort Fenster erscheinen, indem einfach das Passwort eingegeben wird. Bei drei Falscheingaben bricht der FileHandler von RAP! die Verarbeitung der Datei mit einem *read-protected* Fehler ab. Ist das Passwort richtig eingegeben worden, wird es bis zum Neustart intern gespeichert und nicht wieder abgefragt.




## 2.7 ChunkGr��e, OvlGr��e 

Diese zwei Parameter, die auch in allen Einstellungsarten vorkommen, sollten f�r den Normalgebrauch nicht ver�ndert werden. Also �berall auf vererbt gesetzt sein.

Die ChunkGr��e gibt die Anzahl der Bytes an, wie die Dateien beim Speichern oder Lesen zerst�ckelt werden. Zerst�ckelt m�ssen sie deshalb werden, weil sonst bei langen Dateien zu viel RAM-Speicher verbraucht werden w�rde um die Daten zu packen. Und nicht zuletzt deshalb, weil das *Amiga-FileSystem* einen Teilzugriff auf die Daten erlaubt. Desto kleiner dieser Wert ist, desto schlechter ist die *Packrate*, aber desto schneller kann auch per Teilzugriffen auf die Daten zugegriffen werden. N�tzlich ist eine kleine ChunkGr��e nur bei Dateien, bei denen nur bestimmte Daten *herausgefischt* werden (zum Beispiel bei Datenbankdateien). Der voreingestellte Wert ist hier 16384 oder hexadezimal $4000.

Die OvlGr��e gibt die L�nge ein bis zwei interner Speicherbuffer an, die dann verwendet werden, wenn Zeichen innerhalb einer Datei eingef�gt werden oder herausfallen. Haben Sie Dateien wie zum Beispiel wieder bei Datenbanken, die sich �fters selbst modifizieren, kann durch eine Variierung dieses Wertes eine Geschwindigkeitssteigerung erreicht werden. Generell ist aber aus Geschwindigkeitsgr�nden nicht zu empfehlen Dateien zu packen, die sehr oft st�ckchenweise ver�ndert werden.

Die *Vererbungsregeln* gelten nat�rlich auch bei diesen Einstellungen.




## 2.8 VolPr�fix, VolSuffix 

Bei der Verwendung von *entfernbaren Datentr�gern* (zum Beispiel Diskette) erscheint auf der Workbench beim Einlegen der Diskette ein Icon mit dem Namen des Datentr�gers. Da bis jetzt noch technisch bedingt bei einem installierten *RAP-Laufwerk* auf eines der entfernbaren Laufwerke ein zweites Icon erscheint, wurden die Parameter VolPr�fix und VolSuffix eingef�gt.

VolPr�fix gibt eine Zeichenkette an, die vor dem Namen des Datentr�gers erscheinen soll. Voreingestellt ist hier ein "_".

VolSuffix gibt die Zeichenkette an, die nach dem Namen des Datentr�gers erscheinen soll. Voreingestellt ist hier ein "".




## 2.9 HandlerDatei, HandlerStack 

Diese zwei Parameter sind f�r die *zuk�nftige Kompatibilit�t* integriert worden. Diese Werte sollten nur im Notfall ver�ndert oder gesetzt werden.

HandlerDatei gibt den kompletten Pfad und Dateiname des *RAP!-Handlers* an. Voreingestellt ist hier `L:rap-handler`.

Durch die st�ndige Weiterentwicklung des Betriebssystems mu� auch die Stack-Gr��e des Handlers variabel sein. Voreingestellt ist hier der Wert 3072.




# 3 RAP! bei der Arbeit 

Im t�glichen Umgang mit RAP! ergeben sich manchmal kleinere Probleme, die im folgenden Kapitel schon im voraus abgedeckt werden sollten.




## 3.1 Was sollte man nicht komprimieren 

Wie schon in den vorherigen Kapiteln beschrieben, gibt es F�lle, wo man bestimmte Dateien nicht Komprimierung sollte. Die Art der Dateien sowie die Gr�nde f�r kleinere auftretende Probleme werden hier beschrieben.

### 3.1.1 Datenbankdateien 

Wenn m�glich sollten keine *Datenbankdateien* komprimiert werden, mit denen sehr oft gearbeitet wird. Nach unseren bisherigen Experimenten ergeben sich je nach Datenbanksystem enorme *Geschwindigkeitsverz�gerungen*, die zwar durch die Variierung von ChunkGr��e und OvlGr��e verkleinert werden kann, aber dennoch im Vergleich zur ungepackten Verarbeitung zu gro� ist.

### 3.1.2 Disk-Dateien 

Dasselbe Problem gilt f�r Dateien, die einen Datentr�ger mit parallelen Zugriff simulieren. Auch hier gibt es die oben beschriebenen Verz�gerungen. Beachten Sie bitte, da� diese Verz�gerungen nicht durch die Zeit zum Komprimieren oder Entkomprimieren verbraucht wird. RAP! besitzt ein internes System, um Daten im Falle einer inneren Verk�rzung oder Verl�ngerung eines Packabschnittes zu verschieben.

### 3.1.3 komprimierte Dateien 

Vermeiden Sie das Komprimieren von schon komprimierten Dateien. Das kostet nur Zeit, und die Datei wird m�glicherweise sogar l�nger.

### 3.1.4 Systemdateien 

Falls zum Beispiel eine Workbench komprimiert werden soll, ist es wichtig zu wissen, da� alle Verzeichnisse, die Daten enthalten k�nnten die das *RAP!-system* sowie die Workbench beim Initialisieren ben�tigt, nat�rlich nicht komprimiert werden d�rfen. Es ist sowieso nie sicher au�er den Verzeichnissen "Utilities", "Tools" und "Prefs" eine Workbench zu komprimieren, da aus den anderen Verzeichnissen schon beim Start Daten ben�tigt werden.

### 3.1.5 Wichtige Daten 

RAP! hat zwar schon eine monatelange Testphase hinter sich gebracht, aber es kann trotzdem der Datenverlust nie ausgeschlossen werden. Die Kodierung oder Komprimierung von wichtigen oder einmaligen Daten sollte vermieden werden.




## 3.2 komprimierte Dateien verarbeiten. 

Da auch der Zugriff auf das untere Laufwerk noch erlaubt wird, also bei der Laufwerkszuweisung von zum Beispiel "DF0:  -> RAP:" ein Zugriff auf die komprimierten Daten des Laufwerkes "RAP:" �ber "DF0:" erlaubt sind, k�nnen auch die gepackten Daten verarbeitet werden. Besonders im Bereich der *DF�* oder beim fileweisen Kopieren von einem *RAP-Laufwerk* auf ein anderes hat dieser Zugriff Vorteile.

Beachten Sie aber immer, da� eine RAP!-komprimierte Datei nicht auf ein *RAP-Laufwerk* kopiert werden darf. Sind zum Beispiel zwei Laufwerke "DF0:", "DF1:" sowie die dazugeh�rigen RAP-Laufwerke "RAP0:" und "RAP1:" angemeldet, sollten niemals komprimierte Dateien von "DF0:" auf "RAP1:" kopiert werden, da sie dadurch nochmals komprimiert werden.

Um die doppelt komprimierte Datei wieder in das urspr�ngliche Format zur�ckzubekommen, mu� sie wieder von "RAP1:" auf "DF0:" zur�ckkopiert werden. Dann kann wieder wie gewohnt auf "RAP0:" zugegriffen werden.




## 3.3 Installationen �bertragen 

Die einfachste M�glichkeit eine *Programminstallation* auf ein *RAP-Laufwerk* zu �bertragen, ist die erneute Installation.

Ist dies nicht m�glich, sollte nach der Aktualisierung der dazugeh�rigen Dateien, alle eventuellen *Assign-Befehle*, die sich in der *User-Startup* oder *Startup-Sequence* befinden und sich auf die Installation des Programms beziehen, so ge�ndert werden, da� sie sich nun auf das *RAP-Laufwerk* beziehen.




## 3.4 Workbench-Benutzung 

Ab der Kickstart 2 ist es m�glich, Programme auf die Workbench herauszulegen. Dies ist momentan noch nicht mit *RAP-Laufwerken* m�glich.

Bitte beachten Sie auch, da� durch das Umbenennen von Dateien, die sich auf einem RAP-Laufwerk befinden, nicht bearbeitet werden, da das Umbenennen keinen Kopiervorgang startet, sondern nur Blockzeiger korrigiert. Verwenden Sie hierf�r dann anschlie�end die Aktualisierung.
























# Anhang 

## Anhang A, *Defaultwerte* der globalen Einstellungen 

Wenn in den globalen Laufwerkseinstellungen die Parameter nicht gesetzt werden (im *Vererbungsknopf* die 3 Rechtecke verbunden sind), sind folgende Werte voreingestellt:

VolPr�fix:	"_"  
VolSuffix:	""  
ChunkGr��e:	16384, hexadezimal $4000  
OvlGr��e:	8192, hexadezimal $2000  
HandlerStack:	3072, hexadezimal  $c00  
HandlerDatei:	`l:rap-handler`

Packer und Crypter sind ausgeschaltet.




## Anhang B, Aufbau der *Konfigurationsdatei* 

Nach Einstellung der n�tigen Parameter wird in RAP!-Prefs beim Speichern eine Datei namens `RAP.Config` je nach Vorhandensein in das "ENVARC:" oder "S:" Verzeichnis kopiert. Diese Datei besteht nicht wie �blich aus einer Bin�rdatei, sondern beinhaltet die aktuellen Einstellung in Form einer einfachen ASCII *Sprachanweisung*. Diese Informationen k�nnen mit Hilfe eines handels�blichen Editors oder mit dem bei der Workbench beigelegten "ED", ver�ndert werden. N�heres finden Sie hierzu in Ihrem *DOS-Handbuch*.

Folgende *Schl�sselw�rter* werden erkannt:

volprefix &lt;Zeichenkette>;

-  Dient zur Festsetzung der Zeichenkette, die vor den Namen des RAP-Laufwerks stehen soll. 

volsuffix &lt;Zeichenkette>;

-  Die Zeichenkette, die angef�gt wird. 

crypter &lt;Wert1>,&lt;Wert2>;

-  Stellt den Crypter ein. Wert1 ist der Cryptername, Wert2 der Crypterschl�ssel des verwendeten Passwortes. Zum Ausschalten des Crypters geben Sie bitte `crypter '';` ein. Die Berechnung der *Crypterschl�ssels* geschieht �ber das mitgelieferte *RAP-GetKey* Programm, dem Sie den Packer sowie das Passwort �bergeben. Um nun zum Beispiel den *Crypterschl�ssel* des Passwortes "Test" zu berechnen, mu� folgende Zeile im CLI oder in der Shell eingegeben werden:

	-  RAP-GetKey fast Test 

- Das Ergebnis m��te 0x1D2AFE68 lauten. In der Konfigurationsdatei m��te dann die entsprechende Zeile folgenderma�en aussehen:

	-  crypter 'fast',0x1D2AFE68;  

packer &lt;Wert1>;

-  Stellt den aktuellen Packer ein. Durch die Eingabe von "Packer '';" wird der Packer ausgeschaltet. 

handler &lt;Zeichenkette>;

-  Gibt den Pfad und Name der  HandlerDatei an. 

stack &lt;Wert>;

-  Setzt den HandlerStack auf &lt;Wert> Bytes. 

chunksize &lt;Wert>;

-  Setzt die ChunkGr��e auf &lt;Wert> Bytes. 

ovlsize &lt;Wert>;

-  Setzt die OvlGr��e auf &lt;Wert> Bytes. 

drive &lt;Zeichenkette1>,&lt;Zeichenkette2>{}

-  F�gt ein Laufwerk an. Zeichenkette 1 gibt das *SYS-Laufwerk* an. Zeichenkette 2 das *RAP-Laufwerk*. Wenn weitere *individuelle Parameter* nur innerhalb dieses Laufwerks ge�ndert werden sollen, m�ssen sie nach der Zeichenkette2 innerhalb den geschweiften Klammer eingef�gt werden. Falls keine individuellen Parameter verwenden werden, werden die aktuellen, globalen Parameter vererbt. 

drive "ram:","rap:";

-  F�gt das Laufwerk "rap:" an. �bernimmt die Parameter aus dem globalen Bereich der *Konfigurationsdatei*. 

include &lt;Zeichenkette>{}

-  F�gt ein Pfad an. Wie bei den *Laufwerkseinstellungen* k�nnen hier auch individuelle Parameter f�r diesen Pfad gesetzt werden. Auch Platzhalter sind hier m�glich (siehe hierzu Anhang F). 

exclude &lt;Zeichenkette>{}

-  F�gt einen Pfad an, der nicht bearbeitet werden soll. Auch hier k�nnen individuelle Parameter f�r weitere Unterpfade gesetzt werden. Die eingegebene Zeichenkette kann auch wie im Anhang F beschrieben Platzhalter verwenden. 



Um das Ganze noch ein wenig zu verdeutlichen, folgendes Beispiel:

	
	01 packer 'scn1';
	02 drive "ram:","rap:"
	03 {
	04   exclude "*";
	05   include "verzeichnis1";
	06   include "verzeichnis2"
	07   {
	08     packer 'runl';
	09   }
	10 }
	

In Zeile 1 wird global der Packer "scn1" eingestellt. Das Laufwerk RAP wird nun wie in Zeile 2 f�r das Laufwerk "RAM" hergenommen. In Zeile 4 werden alle Verzeichnisse *excluded*, da wir nur bestimmte Verzeichnisse bearbeiten wollen.

Nun wird in Zeile 5 das Verzeichnis1 wieder eingef�gt, und da kein Packer exklusiv gesetzt wird, wird der weiter oben gesetzte "scn1" verwendet.

Dann wird das Verzeichnis2 angef�gt und mit dem Packer "runl" versehen. Alle Dateien, die nun in dieses Verzeichnis kopiert werden, werden mit dem Packer "runl" komprimiert.



Die verschiedenen Werteingaben k�nnen folgenderma�en aussehen:

Dezimal	12345  
Hexadezimal	0xabcdef  
Zeichen	'wxyz'

Auch werden C und C++ *Kommentare* erkannt.

Beispiel:

/\* Dies ist ein C Kommentar \*/  
// Dies ist ein C++ Kommentar

Bitte beachten Sie auch, da� das Konfigurationsprogramm die *Kommentare* beim Speichern nicht mehr zur�ckschreibt, und ggf. die komplette Formatierung �ndert. Wenn die Konfigurationsdatei *per Hand* abg�ndert wird, sollte das Konfigurationsprogramm nur zum Aktualisieren verwendet werden.




## Anhang C, Fehlermeldungen bei der Verarbeitung der Konfigurationsdatei 

Beim Verarbeiten der Konfigurationsdatei durch RAP-Mount oder im Konfigurationsprogramm selber, k�nnen folgende Fehler auftreten:

*Tokenizer Fehler*:

T1: Nicht unterst�tztes Zeichen

-  Dieses Zeichen wurde nicht erkannt. 

T2: Kein Speicher

-  Zu wenig Speicher frei. 

T3: Zeichenkette nicht abgeschlossen

-  Eine mit '"' eingeleitete Zeichenkette wurde nicht abgeschlossen. 

T4: Zeichenkette zu lang

-  Eine Zeichenkette ist l�nger als 1023 Zeichen. 

T5: Schl�sselwort zu lang

-  Ein Schl�sselwort ist l�nger als 1023 Zeichen. 

T6: Kommentar nicht abgeschlossen

-  Ein C-Kommentar ist nicht abgeschlossen worden. Tritt normalerweise nur am Ende einer Datei auf, wenn die Zeichenkombination "\*/" nicht nach einem "/\*" folgt. 

T7: ASCII-Wert nicht abgeschlossen

-  Der ASCII-Wert wurde nicht durch ein Hochkomma abgeschlossen. 

T8: ASCII-Wert zu gro�

-  Es wurden mehr als 4 Zeichen in einem ASCII-Wert eingegeben. 

T9: Hex-Wert zu gro�

-  Es wurden mehr als 8 hexadezimale Zeichen eingegeben. 

*Parser Fehler*:

P1: Kein Speicher

-  Kein Speicher mehr vorhanden. 

P2: Zeichenkette erwartet

-  Es wird eine Zeichenkette in der Form "Zeichen" erwartet. 

P3: Wert erwartet

-  Es wird ein Wert erwartet. 

P4: Schl�sselwort erwartet

-  Das angegebene Schl�sselwort wurde vom Tokenizer nicht erkannt oder ist nicht vorhanden. 

P6: '}' erwartet

-  Ein durch '{' eingeleiteter Bereich wurde nicht abgeschlossen. 

P7: ',' erwartet

-  Ein Komma wird hier erwartet. Kann zum Beispiel beim Vergessen des Crypterschl�ssels vorkommen. 

P8: '{' oder ';' erwartet

-  Entweder ein Block mu� hier eingeleitet werden, oder ein Semikolon gesetzt werden. Tritt bei Befehlen wie "drive" auf. 

P9: VolPr�fix und VolSuffix = ""

-  VolPr�fix und VolSuffix sind beide = "". Dies darf nicht m�glich sein, sonst w�rden beim Einlegen eines Datentr�gers zwei Icons mit demselben Namen auf der Workbench erscheinen. 

P10: Laufwerk(sname) doppelt verwendet

-  Laufwerksnamen d�rfen nicht doppelt verwendet werden! 

P11: Wert zu klein

-  Ein angegebener Wert unterschreitet die Minimalgr��e. 

P12: Wert zu gro�

-  Ein angegebener Wert �berschreitet die Maximalgr��e. 




## Anhang D, RAP-Mount 

Nicht wie sonst im Amiga-System �blich, wurde f�r RAP! ein eigener *Mount-Befehl* geschrieben, der haupts�chlich die Aufgabe hat, die *Konfigurationsdatei* zu verarbeiten und dann die Laufwerke einzeln anzumelden.

Dieses Programm sollte in Ihrer *Startup-Sequence*, *User-Startup* oder im *`WBStartup`* Verzeichnis der Workbench aufgerufen werden. Letzteres geschieht unter OS2 einfach durch Her�berziehen den Icons.

Als erster optionaler Parameter kann der Name der *Konfigurationsdatei* eingegeben werden (Falls nicht angegeben, wird sie auch von `ENVARC:RAP.Config` oder `S:RAP.Config` geladen).

Durch das optional nachfolgende *Schl�sselwort REMOVE* k�nnen die Laufwerke abgemeldet werden.




## Anhang E, XPK-Standard 

W�hrend der Entwicklungszeit von RAP wurde von einer Gruppe Programmieren ein *Komprimierer-Standard* f�r den Amiga entwickelt, der nun auch von RAP! unterst�tzt wird. Dieser Standard und die dazugeh�rigen Packer sind momentan noch *Public Domain* und somit von jedem zug�nglich. Nach einer erfolgreichen Installation sollten auch die *XPK-Packer* erkannt werden. Bitte beachten Sie, da� die *xpkmaster.library* mit der Versionsnummer gr��er gleich 2 f�r RAP! ben�tigt wird, da in den ersten Versionen noch ein kleiner Fehler vorhanden war, der die Verwendung zusammen mit RAP! ausschlo�.

Beachten Sie bitte, da� durch das Verfahren im *RAP!-System* die Kompressionsraten sich um einige Prozente gegen�ber den angegebenen Zahlen der *XPK-Packer* verschlechtern k�nnen, da die Daten aus technischen Gr�nden in einzelne Bereiche vor dem Komprimieren aufgest�ckelt werden (ChunkGr��e).




## Anhang F, Platzhalter 

In allen Pfadangaben sind sogenannte Platzhalter m�glich einzugeben, wobei folgende Arten unterst�tzt werden:

"\*", "xx\*" sowie "\*xx".

"\*"	gilt f�r alle Dateien oder Verzeichnisse.  
"xx\*"	gilt f�r Dateien oder Verzeichnisse wie "xxtest" oder "xx" oder "xxyz".  
"\*xx"	gilt f�r Dateien oder Verzeichnisse wie "xx" oder "testxx" oder "zyxx".




## Anhang G, Die mitgelieferten Packer "scn1" und "runl". 

Momentan werden zwei Packer mitgeliefert, von denen eigentlich der "runl" Packer nicht verwendet werden sollte, da er nur zur �berpr�fung geschrieben wurde, und in den meisten F�llen die Daten nur um sehr wenig Prozent komprimiert.

Der "scn1" ist momentan einer der schnellsten Amiga LZSS-Packer, der zwar relativ viel (ca. 180KB) Speicher beim Komprimieren ben�tigt, diesen aber bei der Dekomprimierung freigibt. Er hat eine ungef�hre Durchschnittskompression von 40% bis 45%. Bei Textdateien f�llt diese Rate etwas h�her aus.





## Anhang H, Tastaturk�rzel im Konfigurationsprogramm 

Da nicht alle Tastaturk�rzel bei den Funktionskn�pfen mit einem Unterstrich versehen sind, finden Sie nachfolgend noch ein komplette Aufstellung der Tastaturk�rzel.

Basisfenster:

`l`	Laufwerk anf�gen  
`p`	Pfad anf�gen  
`u`	Unterpfad anf�gen

`e`	Eintrag editieren  
`a`	Eintrag aktualisieren

`c`	Block ausschneiden  
`n`	Block anf�gen  
`t`	Block unter-anf�gen

Globale Laufwerkseinstellungen sowie Laufwerkseinstellungen:

`n`	Neues Passwort eingeben  
`Esc`	Abbruch  
`Return`	OK!

Pfadeinstellungen:

`c`	Include - Exclude Umschaltung.  
`l`	Verzeichnis einlesen.  
`n`	Neues Passwort eingeben  
`Esc`	Abbruch  
`Return`	OK!

Passworteingabe:

`Esc`	Abbruch

Alle Hinweisfenster:

`v`	Best�tigung (Knopf am weitesten links)  
`b`	Abbruch oder OK! (Knopf am weitesten rechts)

