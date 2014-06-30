# Inhaltsverzeichnis der Amiga Software RAP! 

Copyright & Anmerkungen zur Freeware Version

Einführung

1	Grundprinzip  
1.1	hierarchisches Dateiverwaltungssystem

2	Das Konfigurationsprogramm  
2.1	Einstieg: Beispiel mit der RAM Disk.  
2.2	Pfadeinstellungen  
2.3	Globale Pfadeinstellungen, Blockfunktionen  
2.4	Aktualisierung  
2.5	Packer  
2.6	Crypter, Passwort  
2.7	ChunkGröße, OvlGröße  
2.8	VolPräfix, VolSuffix  
2.9	HandlerDatei, HandlerStack

3	RAP! bei der Arbeit  
3.1	Was sollte man nicht komprimieren.  
3.1.1	Datenbankdateien  
3.1.2	Disk-Dateien  
3.1.3	komprimierte Dateien  
3.1.4	Systemdateien  
3.1.5	wichtige Daten  
3.2	komprimierte Dateien verarbeiten.  
3.3	Installationen übertragen.  
3.4	Workbench-Benutzung.

Anhang A	Defaultwerte der globalen Einstellungen  
Anhang B	Aufbau der Konfigurationsdatei  
Anhang C	Fehlermeldungen bei der Verarbeitung der Konfigurationsdatei  
Anhang D	RAP-Mount  
Anhang E	XPK-Standard  
Anhang F	Platzhalter  
Anhang G	Die mitgelieferten Packer "scn1" und "runl".  
Anhang H	Tastaturkürzel im Konfigurationsprogramm.

# Copyright & Anmerkungen zur Freeware Version 

RAP! ist ein Anwenderprogramm und ein Treiber für den Amiga, das Dateisysteme während dem Zugriff komprimiert.

RAP! wurde 1992 von Markt & Technik unter den Namen "Simplex Tools" kommerziell veröffentlicht und 2014 als Freeware freigegeben.

Diese Referenz wurde von Guido Ruhl verfasst und mit freundlicher Erlaubnis von Pearson ​Deutschland GmbH zur Verfügung gestellt.

Referenzdokumentation (c) 1992 Pearson ​Deutschland GmbH  
Software (c) 1992 Armin Sander

Die Kompatibilität mit aktuellen Amiga Systemen kann nicht garantiert werden. Bitte sichern Sie alle wichtigen Daten vor der Verwendung. Jegliche Haftung ist ausgeschlossen.

# Einführung 

Durch ständig steigende Rechnergeschwindigkeit und immer effizienteren Algorithmen gehört das Komprimieren von Daten in der Computerwelt zur Alltäglichkeit. Auch auf dem Amiga haben diese Datenkomprimierer vor einigen Jahren den Einzug gehalten.

Üblich sind die Archivierer. Die teilweise umständlich vom AmigaDOS aus aufgerufen werden, um dann mit meistens langen Wartezeiten gesamte Verzeichnisse zu packen. Der Sinn hierin besteht wie der Name schon sagt hauptsächlich in der Archivierung der Daten.

Einige andersdenkende Programmierer sind nun auf die Idee gekommen, komplette Programme zu packen, um sie dann beim Start zu entkomprimieren. Da aber der Programmteil, der die Daten entkomprimiert, vom Betriebssystem aufgerufen werden muß, kann nur das Hauptprogramm - die Datei, die auch wirklich aufgerufen wird - komprimiert werden. Meistens macht das bei größeren Anwendungen wenig Sinn. Bei diesem Verfahren spricht man hier auch vom *Echtzeit-dekomprimieren*, da auf schnelleren Rechnern kaum ein Zeitverlust beim Laden der Datei bemerkbar ist.

Die beiden oben geschilderten Verfahren sind die momentan noch am gebräuchlichsten. RAP! ist der erste professionelle Versuch auf dem Amiga ein anderes, neuartiges System einzuführen, das dem Benutzer den Komprimier- und Entkomprimier-Vorgang unsichtbar abnimmt. Durch dieses Verfahren ist es nun auch möglich reine Daten zu komprimieren und in Echtzeit (beim Laden) zu entkomprimieren, was mit den oben geschilderten Verfahren nur umständlich (programmgesteuert) realisierbar gewesen wären.

Im Gegensatz zu den beiden anderen Verfahren verändert RAP! nach außen hin keine Dateien. RAP! bildet eine Schnittstelle zwischen dem Benutzer (den Programmen) und dem Datenträger. Werden nun vom Benutzer Daten auf den Träger geschrieben, schaltet sich RAP! dazwischen, komprimiert die Daten unsichtbar, und läßt dem Benutzer zum Beispiel im Glauben, daß die Datei doch jederzeit in der Originallänge vorliegt. Genauso ist das Verhalten beim Laden. Unsichtbar, egal, ob Daten in einem Texteditor eingeladen, oder irgendwelche Programme gestartet werden. Nicht einmal das Betriebssystem bekommt etwas davon mit, daß die Daten gepackt wurden. Auch der Benutzer wird zumindest beim entkomprimieren von Daten keinen wesentlichen Unterschied bemerken.




# 1 Grundprinzip 

Da bei Computerprogrammen (zumindest auf dem Amiga) FLEXIBILITÄT groß geschrieben wird, wurde zur Erweiterung des Datenkomprimierers noch einige Zusatzfunktionen integriert, die nachfolgend erklärt werden sollen.




## 1.1 hierarchisches Dateiverwaltungssystem 

Mit RAP! ist es nicht nur möglich eine gesamte Diskette oder Festplattenpartition zu komprimieren, sondern RAP! arbeitet auch Verzeichnis-, beziehungsweise Datei-orientiert. Mit dem *hierarchischen Dateiverwaltungssystem* kann für jedes Verzeichnis. Ja sogar für jede Datei der Komprimierer und einige andere Parameter eingestellt werden.

Wichtig ist in diesem Zusammenhang zu wissen, daß diese vom Benutzer mit Hilfe des Konfigurationsprogramms eingegebene Verzeichnisstruktur nicht transparent zu der wirklich vorhandenen Struktur ist. Es können also irgendwelche Parameter für ein Verzeichnis eingestellt werden, obwohl dieses Verzeichnis momentan noch nicht vorhanden ist. Besonders bei der Verwendung zusammen mit *entfernbaren Datenträger* (Disketten) bringt dieses System Vorteile. Der FileHandler von RAP! überprüft bei jeder Neuerstellung einer Datei die eingestellten Parameter und handelt dann dementsprechend.

Ein weiterer Vorteil ist natürlich auch die Anwendung von sogenannten spezialisierten Packern, oder ganz einfach das Ausschalten des Packers. Es wäre Unsinn ein Verzeichnis zu komprimieren, in dem sich sowieso nur gepackte Archive befinden. Dies kostet nur Zeit, und verursacht sogar in Ausnahmefällen, daß die Dateien intern länger werden.

(technische Anmerkung:  Die Daten werden im unkomprimierten Format gespeichert, aber durch spezielle Verkettungsstrukturen kann die Datei trotzdem länger werden)

Durch diese Hierarchie erlaubt RAP! Ihnen zusätzlich auch eine *Passwortvergabe*. Es ist möglich für jedes Verzeichnis ein anderes Passwort zu vergeben, so daß nun auch mehrere Anwender eines Rechners Ihre privaten Daten vor Zugriffe schützen können. Aus technischen Gründen ist die Dateienstruktur nach außen hin auch bei noch nicht eingegebenem Passwort sichtbar. Nur das Starten oder Verarbeiten der Daten ist nicht möglich. Unter der Amiga-Workbench ergibt sich dadurch ein netter Effekt: die Icons, die für Workbench-Programme notwendig sind (.info-Dateien) werden kodiert, und sind somit nicht mehr von der Workbench aus sichtbar.

Durch die Kodierung der Icons kann dann beim Öffnen eines Verzeichnisses auf der Workbench schon eine lästige *Passwortabfrage* erscheinen. Der FileHandler des RAP!-systems versucht lediglich das Icon zu dekodieren.




# 2 Das Konfigurationsprogramm 

Wie bei anderen Programmen benötigt auch RAP! bestimmte Parameter, die vom Anwender eingestellt werden müssen. Um die Eingabe möglichst einfach zu gestalten, wurde ein Programm entwickelt, das sich in das Konzept der OS2.x Konfigurationsprogramme einreiht.




## 2.1 Einstieg: Beispiel mit der Ram Disk. 

Nach einer erfolgreichen Installation ist der erste Schritt der Aufruf des Konfigurationsprogramms, das sich im "Prefs"-verzeichnis des Datenträgers befindet, auf dem RAP! installiert wurde. Um das Konfiguration zu starten, muß das Icon mit einem Doppelklick angewählt werden.

Wenige Sekunden danach erscheint die Oberfläche von RAPPrefs, *das Basisfenster*, welches horizontal in zwei Bereiche gegliedert ist. Links ein Anzeigebereich, in dem die *Laufwerkseinstellungen* sowie die *Pfadeinstellungen* dargestellt werden, und rechts die Aktionsknöpfe, die wiederum in Unterabschnitten unterteilt sind. Nach einer erfolgreichen Installation sollte in dem linken Anzeigebereich nur ein *GLOBAL:* sichtbar sein.

Um nun in die *globalen Laufwerkseinstellungen* zu gelangen, muß `GLOBAL:` mit einem Doppelklick oder einem Klick mit der anschließenden Auswahl von `Editieren` angewählt werden. Von den *globalen Laufwerkseinstellungen* werden die Einstellungen, die in den *Laufwerkseinstellungen* beziehungsweise *Pfadeinstellungen* nicht gemacht werden, übernommen. Werden in den globalen Einstellungen Parameter nicht gesetzt, werden sie von den intern fest gespeicherten *Default-Werten* (siehe Anhang A) übernommen.

Wir wollen hier die Werte nicht verändern, und stellen nur zum Test einen Packer ein. Klicken Sie hierzu einmal auf den *Vererbungsknopf* (rechts neben dem Text "Packer"), um die Einstellung des Packers zu ermöglichen (der Knopf mit den 2 gefüllten und einem ungefüllten Rechteck). Nun klicken Sie nun noch in die Listenanzeige auf den nach einer erfolgreichen Installation vorhandenen "scn1"-Packer, um Ihn anzuwählen. Wenn Sie jetzt noch den links unten befindliche OK-Knopf drücken, ist der Packer *global* gesetzt.

Wir befinden uns wieder im *Basisfenster*, das bis jetzt noch keine Veränderung erfahren hat. Der Packer wurde zwar schon eingestellt, aber es fehlt noch eine wichtige Information, um das Packen der Dateien zu erlauben. Dem Programm muß noch mitgeteilt werden, für welches Laufwerk die eingestellten Parameter überhaupt gelten sollen. Da die Ram Disk meistens vorhanden ist, werden wir dem Konfigurationsprogramm mitteilen, daß zu Testzwecken zuerst "RAM:" verwendet werden soll.

Wählen Sie hierfür den Knopf `Anfügen/Laufwerk` an, um die *Laufwerkseinstellungen* aufzurufen. Sofort wird eine Ähnlichkeit zu den globalen Einstellungen erkennbar. Einige Parameter können hier neu eingestellt werden, beziehungsweise auf ein bestimmtes Laufwerk *lokalisiert* werden. Momentan werden aber nur die Einstellungen *SYS-Laufwerk* und *RAP-Laufwerk* benötigt. Wählen Sie bei *SYS-Laufwerk* `RAM:` an, und geben Sie bei *RAP-Laufwerk* zum Beispiel ein `RAP:` an. Der *RAP-Laufwerksname* ist beliebig wählbar, darf aber nicht schon einmal verwendet worden sein.

Nun wird "RAP:" zur neuen "RAM:" erklärt. Der Doppelpunkt ist bei beiden Einstellungen optional. Nachdem wieder wie vorher auf den OK!-knopf geklickt wurde, befinden wir uns wieder im *Basisfenster*.

Jetzt ist hier eine Änderung erkennbar. Unter dem `GLOBAL:` müßte eine *Laufwerkszuweisung* `RAM:  -> RAP:` sichtbar werden. Die *Laufwerkszuweisungen* stehen immer in der ersten Spalte und haben ein "->" zwischen den *Laufwerksnamen*. Später können hier noch Pfade angefügt werden.

Um das Programm zu verlassen und die Einstellung auszuprobieren, kann nun im *Basisfenster* auf `Sichern` oder `Verwenden` geklickt werden. Beachten Sie bitte, daß falls beim `Sichern` automatisch die vorhandenen Einstellungen beim nächsten *Bootvorgang* ausgeführt werden, beziehungsweise die *RAP-Laufwerke* aktiv werden.

Nun sollte in den nächsten Sekunden auf Ihrer Workbench zusätzlich zu den sonst vorhandenen Laufwerk-Icons noch ein Icon erscheinen, das den Namen der Ram Disk mit einem anführenden "_" trägt. Es bifinden sich nun auf der Workbench sozusagen zwei Ram Disks. In Wirklichkeit sind die darin abgelegten Daten die selben. Nur die Kommunikation geht verschiedene Wege. Probieren wir es aus. Nehmen Sie ein Icon eines beliebigen Programms und ziehen Sie es auf das Ram-Icon ohne dem "_". Die Datei wird in die Ram Disk kopiert (Achten Sie bitte möglichst auf den freien Speicher). Wenn nun auf die "Ram Disk" doppelgeklickt wird, wird dasselbe Programm in dem Fenster des anderen *Laufwerks* erkennbar. Bei einem Doppelklick auf die Ram_Disk mit "_" erscheint ein Fenster mit dem selben Inhalt. Das Programm befindet sich zweimal in der Ram Disk. Wie vorher aber schon gesagt sind die Daten die selben. Es wird also kein zusätzlicher Speicher benötigt.

So, nun machen wir das Ganze mit Hilfe der Discard oder Delete-Funktion der Workbench wieder rückgängig, und probieren den zweiten Weg aus: Löschen Sie also nun die Datei aus dem Speicher (Sie können hierfür eine der beiden Ram_Disks hernehmen), schließen die Fenster und kopieren Sie die Datei wieder durch Herüberziehen des Icons. Nicht aber wie im vorigen Beispiel in die *normale* Ram_Disk sondern in die neu angelegte. Nach einem bemerkbaren Zeitverlust beendet sich der Kopiervorgang. Es funktioniert also wie oben beschrieben, nur mit dem Unterschied, daß einfach ein anderes Laufwerk hergenommen wurde.

Sehen wir nach, was sich getan hat, indem wir die beiden Fenster der Ram Disk durch Doppelklicken öffnen. Sofort wird erkennbar, daß das *kopierte* Programm nicht mehr in beiden Fenstern sichtbar ist. Nur noch in der "_Ram Disk". Dies ist durch den Umstand zu erklären, daß das Icon gepackt wurde, und somit nur in der Ram Disk sichtbar ist, die vom RAP!-System kontrolliert wird. Hier wird in *Echtzeit* das Icon dekomprimiert und dargestellt. Die Dateien sind im übrigen auch in beiden Ram Disks vorhanden, nur sind sie in der einen ohne "_", die nicht vom *RAP!-System* kontrolliert wird, gepackt abgelegt, und somit für den Anwender fast unbrauchbar. Ausnahme ist das zum Beispiel mögliche Kopieren auf einen anderen mit RAP! versehenen Datenträger (auch per *DFÜ*!), um sich das Entkomprimieren und Rekomprimieren zu ersparen.

Natürlich kann jetzt nicht nur das Icon angezeigt werden, sondern auch das Programm wie gewohnt gestartet werden. Es nimmt weniger Platz auf der Ram-Disk ein, und wird beim Doppelklicken in Echtzeit dekomprimiert und gestartet. Wobei die Dekomprimierung hier wirklich fast immer unmerkbar abläuft.

Vielleicht alles am Anfang etwas schwierig zu verstehen. Aber nach einer kleineren Einarbeitungszeit kommt man schon dahinter, wie man was in welches Verzeichnis kopieren, löschen oder bewegen soll, damit es komprimiert oder dekomprimiert wird.

Komplizierter wird es bei den Pfadeinstellungen, die im nächsten Kapitel eingeführt werden.




## 2.2 Pfadeinstellungen 

Zusätzlich zu den *Laufwerkseinstellungen* kann nun auch für jeden Pfad oder Datei eines Laufwerks Parameter eingestellt werden. Stellen wir uns vor, daß sich zum Beispiel ein Verzeichnis auf Ihrer Festplatte mit dem Namen "arc" befindet, das nur archivierte Dateien enthält. Natürlich ist es nicht sinnvoll dieses Verzeichnis auch noch zu komprimieren, da es ja schon komprimierte Dateien enthält.

Probieren wir es wie im letzten Kapitel beschrieben mit der Ram Disk aus: Falls die *Laufwerkszuweisung* ("RAM:  -> RAP:") nicht schon aktiviert (invertiert) ist, muß sie durch einen Klick angewählt werden, um dem Konfigurationsprogramm mitzuteilen, daß noch Informationen zu diesem Laufwerk anfügt werden.

Durch einen Klick auf den Knopf `Anfügen/Pfad` oder `p`, werden die *Pfadeinstellungen* aufgerufen. Auch hier ähnelt der Bildschirmaufbau dem der *Laufwerkseinstellungen*. Es gibt zwei Arten von *Pfadeinstellungen*: *Exclude und Include*. Ein *Exclude-Pfad* ist ein Pfad, der nicht bearbeitet wird. Er wird also auch zum Beispiel bei einem Zugriff auf das *RAP-Laufwerk* nicht komprimiert, obwohl entsprechende Parameter eingestellt wurden. Da wir das Verzeichnis "arc" später nicht bearbeiten (nicht komprimieren) wollen, müssen diese Pfadeinstellung auf `Exclude` gestellt werden. Dies geschieht, indem das sogenannte Cycle-Gadget gedrückt wird. Die Anzeige sollte nun von `Include` auf `Exclude` wechseln.

Nun fehlt uns noch die *Verzeichnisauswahl*. Das Konfigurationsprogramm muß wissen, welches Verzeichnis es *excluden* muß. Diese Auswahl kann entweder durch einen Druck auf `Lesen` und einer anschließendem Auswahl durch einen Mausklick in der darunterliegenden Listenanzeige geschehen, oder durch Direkteingabe des Verzeichnisses im Eingabefeld unter der Listenanzeige. Hier können auch die im Anhang F beschriebenen Platzhalter verwendet werden.

Falls das Verzeichnis "arc" in der Ram Disk schon erstellt wurde, kann nun mit `Lesen` die Verzeichnisse im Listenfenster angezeigt und augewählt werden. Falls das Verzeichnis noch nicht vorhanden ist, muß per Hand "arc" in das Eingabefeld unter der Listenanzeige eingegeben werden.

Klicken Sie nun auf `OK!` um wieder in das *Basisfenster* zurückzukommen. Auf dem Bildschirm müßte nun folgendes Sichtbar sein:

	
	GLOBAL:        (dunkel oder normal)
	RAM: -> RAP:   (dunkel oder normal)
	  >arc         (hell oder kursiv)
	

Wie Sie vielleicht sofort bemerkt haben, wird das `>arc` hell (oder auf einer *2-farben Workbench* kursiv) dargestellt. Hell ist ein Hinweis darauf, daß diese *Pfadeinstellung* *excluded* ist, also der Pfad arc in der Ram Disk nicht bearbeitet wird.

Mit Hilfe der Funktion `Anfügen/Unterpfad` kann nun auch zum Beispiel ein Unterverzeichnis von "arc" wieder bearbeitet werden. Stellen wir uns vor, daß sich zwar im "arc"-verzeichnis nur komprimierte Dateien befinden, aber ab und zu mal eine komprimierte Datei in das Verzeichnis "arc/unarc" entkomprimiert wird, um die Daten zu anschließend andersweitig zu verarbeiten. In diesem Fall wäre es sicherlich sinnvoll, das Unterverzeichnis "unarc" wieder zu komprimieren, da sich darin nur unkomprimierte Daten befinden.

Wählen Sie also `>arc` durch einen einfachen Klick an, und drücken auf den Knopf `Anfügen/Unterpfad` oder `u` um die *Pfadeinstellungen* für einen Unterpfad anzufügen.

Nun befinden befinden wir uns wieder in den *Pfadeinstellungen*. Hier lassen Sie alles wie gehabt, und geben im Eingabefeld links unten den Pfad "unarc" ein. Falls das Verzeichnis schon existiert kann hier die Auswahl durch einem Druck auf `Lesen` vereinfacht werden.

Nun wieder `OK!` um in das Basisfenster zu gelangen. Die Listenanzeige sollte nun folgendermaßen aussehen:

	
	GLOBAL:        (dunkel oder normal)
	RAM: -> RAP:   (dunkel oder normal)
	  >arc         (hell oder kursiv)
	    >unarc     (dunkel oder normal)
	

Wie Sie schon sehen können ist durch die Angabe von `Anfügen/Unterpfad` "unarc" in eine andere Ebene gerutscht. "unarc" ist weiter rechts von "arc" plaziert, was soviel bedeutet, daß auch in der Dateienstruktur dieses Verzeichnis eine Ebene weiter unten liegt.




## 2.3 Globale Pfadeinstellungen, Blockfunktionen 

Manchmal ist es notwendig, daß bestimmte Pfadeinstellungen auf jedem Datenträger eingestellt werden sollen, die auf jeden durch RAP! angesprochenen Datenträger gemacht werden sollten. Sollen zum Beispiel mehrere Festplatten oder Disketten, auf denen sich je ein "arc"-verzeichnis befindet, das nicht gepackt werden soll, bearbeitet werden, ist es zwar mit den *Blockfunktionen* möglich die Parameter an ein anderes Laufwerk anzufügen, würde aber nach einiger Zeit ziemlich irritierend werden. Um nun eine *globale Pfadeinstellung* vorzunehmen, klicken Sie beim `Anfügen/Pfad` nicht vorher auf ein Laufwerk in der *Listenanzeige*, sondern auf `GLOBAL:`. Falls noch das Beispiel im vorherigen Kapitel eingestellt ist, können hier auch gleich die *Blockfunktionen* ausprobiert werden:

Klicken Sie `>arc` an, und gehen auf die Blockfunktion `Ausschneiden` rechts unten, oder drücken Sie `c`. Schon ist der Pfad `>arc` und wie vielleicht nicht voraussehbar auch der Pfad `>unarc` verschwunden. Beim Ausschneiden werden aus rein logischen Gründen auch die gesamten Unterpfade des Laufwerks oder des Pfades ausgeschnitten. Diese Daten befinden sich nun in einem unsichtbaren Zwischenspeicher, der mit `Block/Anfügen` und `Block/Unter-Anfügen` an eine andere Stelle im *Listenfenster* wieder angefügt werden kann.

Klicken Sie nun auf `GLOBAL:`, da wir Pfade an die *globalen Einstellungen* anfügen wollen, und dann auf `Block/Anfügen`. Folgendes Bild sollte sich ergeben:

	
	GLOBAL:        (dunkel oder normal)
	  >arc         (hell oder kursiv)
	    >unarc     (dunkel oder normal)
	RAM: -> RAP:   (dunkel oder normal)
	

Falls nun in Zukunft noch mehrere Laufwerke angefügt werden (dies geschieht zum Beispiel mit einem Klick auf `RAM:  -> RAP:` und `Anfügen/Laufwerk`), werden wie die *globalen Laufwerkseinstellungen* (Doppelklick auf `GLOBAL:`) für jedes Laufwerk immer die *globalen Pfadeinstellungen* *vererbt*.

Die vererbten Parameter können durch die Angabe neuer Parameter in den *Laufwerkseinstellungen* und *Pfadeinstellungen* geändert werden. Die *Vererbung* wird dann aber in die weiter unteren liegenden Ebenen übertragen. Ein kleines Beispiel mit dem Packer:

	
	GLOBAL:        (dunkel oder normal) (Packer: scn1)
	RAM: -> RAP:   (dunkel oder normal) (Packer nicht gesetzt)
	  >verz1       (dunkel oder normal) (Packer: scnx)
	    >verz2     (dunkel oder normal) (Packer nicht gesetzt)
	

Global ist die oberste Ebene in der der Packer "scn1" gesetzt wurde. In der *Laufwerkszuweisung* eine Zeile darunter wird kein Packer gesetzt, also der Packer aus einer Ebene drüber verwendet (scn1). Das Verzeichnis 1 unterbricht diese Vererbung, und setzt für sich und für das Verzeichnis 2, das ja eine Ebene unter Verzeichnis 1 liegt, einen anderen Packer (scnx). Folgende Parameter sind also nun für die einzelnen Einstellungen gültig:

	
	GLOBAL:        (dunkel oder normal) (Packer: scn1)
	RAM: -> RAP:   (dunkel oder normal) (Packer: scn1 / wurde vererbt)
	  >verz1       (dunkel oder normal) (Packer: scnx)
	    >verz2     (dunkel oder normal) (Packer: scnx / wurde vererbt)
	

Diese Beispiele sollen einigermaßen die *Vererbungslogik* verdeutlichen. Natürlich richten sich auch alle anderen einstellbaren Parameter nach diesem System.




## 2.4 Aktualisierung 

Falls nun alle gewünschten Parameter im Konfigurationsprogramm eingestellt wurden, ist der Schritt vor dem Abspeichern der Konfiguration noch die *Aktualisierung*. Je nach dem, was momentan gerade in der *Listenanzeige* im *Basisfenster* ausgewählt ist, können Unterverzeichnisse oder gesamte Laufwerke aktualisiert werden. In der Aktualisierung werden alle Daten auf den neusten Stand gebracht. Wenn zum Beispiel in irgendeinem Verzeichnis der Packer oder das Passwort geändert wurde, erkennt die Aktualisierung das vollkommen automatisch und packt oder verschlüsselt die Daten neu.

Da wie schon vorher berichtet die Verzeichnisstruktur im Konfigurationsprogramm nicht mit der aktuell auf dem Datenträger vorhandenen Struktur gleich sein muß, kann beim Anklicken auf `Aktualisieren` ein Hinweisfenster erscheinen, das Sie bittet, doch ein übergeordnetes Verzeichnis zu aktualisieren.

Falls das *Aktualisieren-Fenster* erscheint, kann mit Hilfe des `Start` Knopfes die Aktualisierung begonnen werden. In der darüber liegenden Anzeige werden die Dateien angezeigt, die aktualisiert werden. Mit Hilfe von `Alles anzeigen` können auch die Dateien angezeigt werden, die zwar gefunden wurden, aber nicht bearbeitet werden.

Beim Start wechselt der `Start` Knopf in ein `Pause` Knopf, der bei Betätigung die Aktualisierung unterbricht und sich in einen `Weiter` Knopf verwandelt. Nach Druck auf `Weiter` wird die Aktualisierung fortgesetzt.

Die verschiedenen Dateien werden je nach Bearbeitungsmodus in folgenden Farben dargestellt:

	Normal	Alles anzeigen

Datei aktualisiert	dunkel	Farbe 3 (blau)  
Datei Exclude/nicht aktualisiert	keine Anzeige	hell  
Datei Include/nicht aktualisiert	keine Anzeige	dunkel

Die Aktualisierung kann jederzeit mit `Abbruch` beendet werden.

Bitte beachten Sie, daß vor der Aktualisierung noch genügend *Speicherplatz* vorhanden ist. Wenn nicht genügend Speicher vorhanden ist, kann es vorkommen, daß die Daten zum Beispiel nicht komprimiert werden!




## 2.5 Packer 

In in jeder Art der Einstellungsfenster (*globale Laufwerkseinstellungen*, *Laufwerkseinstellungen* und *Pfadeinstellungen*) ist die Vergabe eines Packers möglich. Vererbt werden die Einstellungen des Übergeordneten Eintrages dann, wenn der *Vererbungsknopf* rechts oben über der *Listenanzeige* keine Verbindungen zwischen den drei Rechtecken aufweist, und die Listenanzeige nicht in Geisterschrift angezeigt wird (überzogen mit einem schwarzem Pixel-Muster).

Die Anzahl und das Vorhandensein der Packer kann variieren. Es werden die *RAP!-Packer* anerkannt die sich auf Ihrem *Bootmedium* im Verzeichnis `Libs:pack` befinden. Momentan nur "scn1" und "runl". Mit Hilfe der PD-Veröffentlichung des *XPK-Standards* können weitere Packer eingebunden werden, die sich dann im `Libs:compressors` Verzeichnis befinden. Die Anzeige der *XPK-Packer* geschieht automatisch. Die *RAP!-packer* werden in kleiner Schrift dargestellt, die *XPK-Packer* in Großschrift. Da sich noch in der alten Version der *XPK-Library* ein Fehler befand, der die Verwendung für RAP! ausschloß, ist die Verwendung von *XPK-Packer* erst ab der `xpkmaster.library` Version 2 möglich.

Die Ausschaltung des Packers geschieht durch das einfache Löschen der 4 Packer-Buchstaben unter der Listenanzeige liegendem Eingabefeld. In diesem Fall muß die Vererbung ausgeschaltet sein.




## 2.6 Crypter, Passwort 

Auch wie die oben geschilderte Packer-Einstellung kann in jeder Einstellungsart ein Crypter sowie ein Passwort eingestellt werden: Mit Hilfe des Passwortes können Daten vor fremden Zugriff geschützt werden. Auch hier gelten die üblichen *Vererbungsregeln*, die schon ausreichend erklärt wurden.

Bis jetzt werden nur die *RAP!-Crypter* unterstützt. Einer befindet sich nach der erfolgreichen Installation im Verzeichnis `Libs:crypt`, der den Namen "fast" trägt. Wie der Name schon sagt, ist er relativ schnell, und sollte keine Zeitverzögerungen aufweisen.

Die Einstellung geschieht genauso wie bei den Packer. Das Löschen auch durch das Löschen der 4 Buchstaben im Eingabefeld unter der Listenanzeige. Zusätzlich zu dieser Einstellung benötigen wir nun auch ein Passwort. Dieses Passwort wird mit Hilfe des Knopfes `Neu` verändert. Falls ein Crypter gesetzt wurde, erscheint nun ein Fenster, worin das Passwort eingegeben werden kann. Falls zuvor ein Passwort schon gesetzt war, wird es auch in diesem Fenster abgefragt. Nach erfolgreicher Eingabe wird das Passwort einmalig links neben dem `Neu` in der Anzeige dargestellt. Bitte merken Sie sich nun das Passwort, denn es wird nie wieder erscheinen. Aus Sicherheitsgründen wird das Passwort nicht gespeichert, sondern nur ein Prüfsumme, aus der lediglich die Richtigkeit eines Passwortes hergeleitet wird, nicht aber der genaue Name.

Es ist nicht wieder möglich das Passwort herauszufinden. Bitte achten Sie genau darauf, welche Zeichen Sie eingeben.

Im späteren Betrieb wird nach jedem Neustart des Rechners bei einem Zugriff auf eine kodierte Datei ein Passwort Fenster erscheinen, indem einfach das Passwort eingegeben wird. Bei drei Falscheingaben bricht der FileHandler von RAP! die Verarbeitung der Datei mit einem *read-protected* Fehler ab. Ist das Passwort richtig eingegeben worden, wird es bis zum Neustart intern gespeichert und nicht wieder abgefragt.




## 2.7 ChunkGröße, OvlGröße 

Diese zwei Parameter, die auch in allen Einstellungsarten vorkommen, sollten für den Normalgebrauch nicht verändert werden. Also überall auf vererbt gesetzt sein.

Die ChunkGröße gibt die Anzahl der Bytes an, wie die Dateien beim Speichern oder Lesen zerstückelt werden. Zerstückelt müssen sie deshalb werden, weil sonst bei langen Dateien zu viel RAM-Speicher verbraucht werden würde um die Daten zu packen. Und nicht zuletzt deshalb, weil das *Amiga-FileSystem* einen Teilzugriff auf die Daten erlaubt. Desto kleiner dieser Wert ist, desto schlechter ist die *Packrate*, aber desto schneller kann auch per Teilzugriffen auf die Daten zugegriffen werden. Nützlich ist eine kleine ChunkGröße nur bei Dateien, bei denen nur bestimmte Daten *herausgefischt* werden (zum Beispiel bei Datenbankdateien). Der voreingestellte Wert ist hier 16384 oder hexadezimal $4000.

Die OvlGröße gibt die Länge ein bis zwei interner Speicherbuffer an, die dann verwendet werden, wenn Zeichen innerhalb einer Datei eingefügt werden oder herausfallen. Haben Sie Dateien wie zum Beispiel wieder bei Datenbanken, die sich öfters selbst modifizieren, kann durch eine Variierung dieses Wertes eine Geschwindigkeitssteigerung erreicht werden. Generell ist aber aus Geschwindigkeitsgründen nicht zu empfehlen Dateien zu packen, die sehr oft stückchenweise verändert werden.

Die *Vererbungsregeln* gelten natürlich auch bei diesen Einstellungen.




## 2.8 VolPräfix, VolSuffix 

Bei der Verwendung von *entfernbaren Datenträgern* (zum Beispiel Diskette) erscheint auf der Workbench beim Einlegen der Diskette ein Icon mit dem Namen des Datenträgers. Da bis jetzt noch technisch bedingt bei einem installierten *RAP-Laufwerk* auf eines der entfernbaren Laufwerke ein zweites Icon erscheint, wurden die Parameter VolPräfix und VolSuffix eingefügt.

VolPräfix gibt eine Zeichenkette an, die vor dem Namen des Datenträgers erscheinen soll. Voreingestellt ist hier ein "_".

VolSuffix gibt die Zeichenkette an, die nach dem Namen des Datenträgers erscheinen soll. Voreingestellt ist hier ein "".




## 2.9 HandlerDatei, HandlerStack 

Diese zwei Parameter sind für die *zukünftige Kompatibilität* integriert worden. Diese Werte sollten nur im Notfall verändert oder gesetzt werden.

HandlerDatei gibt den kompletten Pfad und Dateiname des *RAP!-Handlers* an. Voreingestellt ist hier `L:rap-handler`.

Durch die ständige Weiterentwicklung des Betriebssystems muß auch die Stack-Größe des Handlers variabel sein. Voreingestellt ist hier der Wert 3072.




# 3 RAP! bei der Arbeit 

Im täglichen Umgang mit RAP! ergeben sich manchmal kleinere Probleme, die im folgenden Kapitel schon im voraus abgedeckt werden sollten.




## 3.1 Was sollte man nicht komprimieren 

Wie schon in den vorherigen Kapiteln beschrieben, gibt es Fälle, wo man bestimmte Dateien nicht Komprimierung sollte. Die Art der Dateien sowie die Gründe für kleinere auftretende Probleme werden hier beschrieben.

### 3.1.1 Datenbankdateien 

Wenn möglich sollten keine *Datenbankdateien* komprimiert werden, mit denen sehr oft gearbeitet wird. Nach unseren bisherigen Experimenten ergeben sich je nach Datenbanksystem enorme *Geschwindigkeitsverzögerungen*, die zwar durch die Variierung von ChunkGröße und OvlGröße verkleinert werden kann, aber dennoch im Vergleich zur ungepackten Verarbeitung zu groß ist.

### 3.1.2 Disk-Dateien 

Dasselbe Problem gilt für Dateien, die einen Datenträger mit parallelen Zugriff simulieren. Auch hier gibt es die oben beschriebenen Verzögerungen. Beachten Sie bitte, daß diese Verzögerungen nicht durch die Zeit zum Komprimieren oder Entkomprimieren verbraucht wird. RAP! besitzt ein internes System, um Daten im Falle einer inneren Verkürzung oder Verlängerung eines Packabschnittes zu verschieben.

### 3.1.3 komprimierte Dateien 

Vermeiden Sie das Komprimieren von schon komprimierten Dateien. Das kostet nur Zeit, und die Datei wird möglicherweise sogar länger.

### 3.1.4 Systemdateien 

Falls zum Beispiel eine Workbench komprimiert werden soll, ist es wichtig zu wissen, daß alle Verzeichnisse, die Daten enthalten könnten die das *RAP!-system* sowie die Workbench beim Initialisieren benötigt, natürlich nicht komprimiert werden dürfen. Es ist sowieso nie sicher außer den Verzeichnissen "Utilities", "Tools" und "Prefs" eine Workbench zu komprimieren, da aus den anderen Verzeichnissen schon beim Start Daten benötigt werden.

### 3.1.5 Wichtige Daten 

RAP! hat zwar schon eine monatelange Testphase hinter sich gebracht, aber es kann trotzdem der Datenverlust nie ausgeschlossen werden. Die Kodierung oder Komprimierung von wichtigen oder einmaligen Daten sollte vermieden werden.




## 3.2 komprimierte Dateien verarbeiten. 

Da auch der Zugriff auf das untere Laufwerk noch erlaubt wird, also bei der Laufwerkszuweisung von zum Beispiel "DF0:  -> RAP:" ein Zugriff auf die komprimierten Daten des Laufwerkes "RAP:" über "DF0:" erlaubt sind, können auch die gepackten Daten verarbeitet werden. Besonders im Bereich der *DFÜ* oder beim fileweisen Kopieren von einem *RAP-Laufwerk* auf ein anderes hat dieser Zugriff Vorteile.

Beachten Sie aber immer, daß eine RAP!-komprimierte Datei nicht auf ein *RAP-Laufwerk* kopiert werden darf. Sind zum Beispiel zwei Laufwerke "DF0:", "DF1:" sowie die dazugehörigen RAP-Laufwerke "RAP0:" und "RAP1:" angemeldet, sollten niemals komprimierte Dateien von "DF0:" auf "RAP1:" kopiert werden, da sie dadurch nochmals komprimiert werden.

Um die doppelt komprimierte Datei wieder in das ursprüngliche Format zurückzubekommen, muß sie wieder von "RAP1:" auf "DF0:" zurückkopiert werden. Dann kann wieder wie gewohnt auf "RAP0:" zugegriffen werden.




## 3.3 Installationen übertragen 

Die einfachste Möglichkeit eine *Programminstallation* auf ein *RAP-Laufwerk* zu übertragen, ist die erneute Installation.

Ist dies nicht möglich, sollte nach der Aktualisierung der dazugehörigen Dateien, alle eventuellen *Assign-Befehle*, die sich in der *User-Startup* oder *Startup-Sequence* befinden und sich auf die Installation des Programms beziehen, so geändert werden, daß sie sich nun auf das *RAP-Laufwerk* beziehen.




## 3.4 Workbench-Benutzung 

Ab der Kickstart 2 ist es möglich, Programme auf die Workbench herauszulegen. Dies ist momentan noch nicht mit *RAP-Laufwerken* möglich.

Bitte beachten Sie auch, daß durch das Umbenennen von Dateien, die sich auf einem RAP-Laufwerk befinden, nicht bearbeitet werden, da das Umbenennen keinen Kopiervorgang startet, sondern nur Blockzeiger korrigiert. Verwenden Sie hierfür dann anschließend die Aktualisierung.
























# Anhang 

## Anhang A, *Defaultwerte* der globalen Einstellungen 

Wenn in den globalen Laufwerkseinstellungen die Parameter nicht gesetzt werden (im *Vererbungsknopf* die 3 Rechtecke verbunden sind), sind folgende Werte voreingestellt:

VolPräfix:	"_"  
VolSuffix:	""  
ChunkGröße:	16384, hexadezimal $4000  
OvlGröße:	8192, hexadezimal $2000  
HandlerStack:	3072, hexadezimal  $c00  
HandlerDatei:	`l:rap-handler`

Packer und Crypter sind ausgeschaltet.




## Anhang B, Aufbau der *Konfigurationsdatei* 

Nach Einstellung der nötigen Parameter wird in RAP!-Prefs beim Speichern eine Datei namens `RAP.Config` je nach Vorhandensein in das "ENVARC:" oder "S:" Verzeichnis kopiert. Diese Datei besteht nicht wie üblich aus einer Binärdatei, sondern beinhaltet die aktuellen Einstellung in Form einer einfachen ASCII *Sprachanweisung*. Diese Informationen können mit Hilfe eines handelsüblichen Editors oder mit dem bei der Workbench beigelegten "ED", verändert werden. Näheres finden Sie hierzu in Ihrem *DOS-Handbuch*.

Folgende *Schlüsselwörter* werden erkannt:

volprefix &lt;Zeichenkette>;

-  Dient zur Festsetzung der Zeichenkette, die vor den Namen des RAP-Laufwerks stehen soll. 

volsuffix &lt;Zeichenkette>;

-  Die Zeichenkette, die angefügt wird. 

crypter &lt;Wert1>,&lt;Wert2>;

-  Stellt den Crypter ein. Wert1 ist der Cryptername, Wert2 der Crypterschlüssel des verwendeten Passwortes. Zum Ausschalten des Crypters geben Sie bitte `crypter '';` ein. Die Berechnung der *Crypterschlüssels* geschieht über das mitgelieferte *RAP-GetKey* Programm, dem Sie den Packer sowie das Passwort übergeben. Um nun zum Beispiel den *Crypterschlüssel* des Passwortes "Test" zu berechnen, muß folgende Zeile im CLI oder in der Shell eingegeben werden:

	-  RAP-GetKey fast Test 

- Das Ergebnis müßte 0x1D2AFE68 lauten. In der Konfigurationsdatei müßte dann die entsprechende Zeile folgendermaßen aussehen:

	-  crypter 'fast',0x1D2AFE68;  

packer &lt;Wert1>;

-  Stellt den aktuellen Packer ein. Durch die Eingabe von "Packer '';" wird der Packer ausgeschaltet. 

handler &lt;Zeichenkette>;

-  Gibt den Pfad und Name der  HandlerDatei an. 

stack &lt;Wert>;

-  Setzt den HandlerStack auf &lt;Wert> Bytes. 

chunksize &lt;Wert>;

-  Setzt die ChunkGröße auf &lt;Wert> Bytes. 

ovlsize &lt;Wert>;

-  Setzt die OvlGröße auf &lt;Wert> Bytes. 

drive &lt;Zeichenkette1>,&lt;Zeichenkette2>{}

-  Fügt ein Laufwerk an. Zeichenkette 1 gibt das *SYS-Laufwerk* an. Zeichenkette 2 das *RAP-Laufwerk*. Wenn weitere *individuelle Parameter* nur innerhalb dieses Laufwerks geändert werden sollen, müssen sie nach der Zeichenkette2 innerhalb den geschweiften Klammer eingefügt werden. Falls keine individuellen Parameter verwenden werden, werden die aktuellen, globalen Parameter vererbt. 

drive "ram:","rap:";

-  Fügt das Laufwerk "rap:" an. Übernimmt die Parameter aus dem globalen Bereich der *Konfigurationsdatei*. 

include &lt;Zeichenkette>{}

-  Fügt ein Pfad an. Wie bei den *Laufwerkseinstellungen* können hier auch individuelle Parameter für diesen Pfad gesetzt werden. Auch Platzhalter sind hier möglich (siehe hierzu Anhang F). 

exclude &lt;Zeichenkette>{}

-  Fügt einen Pfad an, der nicht bearbeitet werden soll. Auch hier können individuelle Parameter für weitere Unterpfade gesetzt werden. Die eingegebene Zeichenkette kann auch wie im Anhang F beschrieben Platzhalter verwenden. 



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
	

In Zeile 1 wird global der Packer "scn1" eingestellt. Das Laufwerk RAP wird nun wie in Zeile 2 für das Laufwerk "RAM" hergenommen. In Zeile 4 werden alle Verzeichnisse *excluded*, da wir nur bestimmte Verzeichnisse bearbeiten wollen.

Nun wird in Zeile 5 das Verzeichnis1 wieder eingefügt, und da kein Packer exklusiv gesetzt wird, wird der weiter oben gesetzte "scn1" verwendet.

Dann wird das Verzeichnis2 angefügt und mit dem Packer "runl" versehen. Alle Dateien, die nun in dieses Verzeichnis kopiert werden, werden mit dem Packer "runl" komprimiert.



Die verschiedenen Werteingaben können folgendermaßen aussehen:

Dezimal	12345  
Hexadezimal	0xabcdef  
Zeichen	'wxyz'

Auch werden C und C++ *Kommentare* erkannt.

Beispiel:

/\* Dies ist ein C Kommentar \*/  
// Dies ist ein C++ Kommentar

Bitte beachten Sie auch, daß das Konfigurationsprogramm die *Kommentare* beim Speichern nicht mehr zurückschreibt, und ggf. die komplette Formatierung ändert. Wenn die Konfigurationsdatei *per Hand* abgändert wird, sollte das Konfigurationsprogramm nur zum Aktualisieren verwendet werden.




## Anhang C, Fehlermeldungen bei der Verarbeitung der Konfigurationsdatei 

Beim Verarbeiten der Konfigurationsdatei durch RAP-Mount oder im Konfigurationsprogramm selber, können folgende Fehler auftreten:

*Tokenizer Fehler*:

T1: Nicht unterstütztes Zeichen

-  Dieses Zeichen wurde nicht erkannt. 

T2: Kein Speicher

-  Zu wenig Speicher frei. 

T3: Zeichenkette nicht abgeschlossen

-  Eine mit '"' eingeleitete Zeichenkette wurde nicht abgeschlossen. 

T4: Zeichenkette zu lang

-  Eine Zeichenkette ist länger als 1023 Zeichen. 

T5: Schlüsselwort zu lang

-  Ein Schlüsselwort ist länger als 1023 Zeichen. 

T6: Kommentar nicht abgeschlossen

-  Ein C-Kommentar ist nicht abgeschlossen worden. Tritt normalerweise nur am Ende einer Datei auf, wenn die Zeichenkombination "\*/" nicht nach einem "/\*" folgt. 

T7: ASCII-Wert nicht abgeschlossen

-  Der ASCII-Wert wurde nicht durch ein Hochkomma abgeschlossen. 

T8: ASCII-Wert zu groß

-  Es wurden mehr als 4 Zeichen in einem ASCII-Wert eingegeben. 

T9: Hex-Wert zu groß

-  Es wurden mehr als 8 hexadezimale Zeichen eingegeben. 

*Parser Fehler*:

P1: Kein Speicher

-  Kein Speicher mehr vorhanden. 

P2: Zeichenkette erwartet

-  Es wird eine Zeichenkette in der Form "Zeichen" erwartet. 

P3: Wert erwartet

-  Es wird ein Wert erwartet. 

P4: Schlüsselwort erwartet

-  Das angegebene Schlüsselwort wurde vom Tokenizer nicht erkannt oder ist nicht vorhanden. 

P6: '}' erwartet

-  Ein durch '{' eingeleiteter Bereich wurde nicht abgeschlossen. 

P7: ',' erwartet

-  Ein Komma wird hier erwartet. Kann zum Beispiel beim Vergessen des Crypterschlüssels vorkommen. 

P8: '{' oder ';' erwartet

-  Entweder ein Block muß hier eingeleitet werden, oder ein Semikolon gesetzt werden. Tritt bei Befehlen wie "drive" auf. 

P9: VolPräfix und VolSuffix = ""

-  VolPräfix und VolSuffix sind beide = "". Dies darf nicht möglich sein, sonst würden beim Einlegen eines Datenträgers zwei Icons mit demselben Namen auf der Workbench erscheinen. 

P10: Laufwerk(sname) doppelt verwendet

-  Laufwerksnamen dürfen nicht doppelt verwendet werden! 

P11: Wert zu klein

-  Ein angegebener Wert unterschreitet die Minimalgröße. 

P12: Wert zu groß

-  Ein angegebener Wert überschreitet die Maximalgröße. 




## Anhang D, RAP-Mount 

Nicht wie sonst im Amiga-System üblich, wurde für RAP! ein eigener *Mount-Befehl* geschrieben, der hauptsächlich die Aufgabe hat, die *Konfigurationsdatei* zu verarbeiten und dann die Laufwerke einzeln anzumelden.

Dieses Programm sollte in Ihrer *Startup-Sequence*, *User-Startup* oder im *`WBStartup`* Verzeichnis der Workbench aufgerufen werden. Letzteres geschieht unter OS2 einfach durch Herüberziehen den Icons.

Als erster optionaler Parameter kann der Name der *Konfigurationsdatei* eingegeben werden (Falls nicht angegeben, wird sie auch von `ENVARC:RAP.Config` oder `S:RAP.Config` geladen).

Durch das optional nachfolgende *Schlüsselwort REMOVE* können die Laufwerke abgemeldet werden.




## Anhang E, XPK-Standard 

Während der Entwicklungszeit von RAP wurde von einer Gruppe Programmieren ein *Komprimierer-Standard* für den Amiga entwickelt, der nun auch von RAP! unterstützt wird. Dieser Standard und die dazugehörigen Packer sind momentan noch *Public Domain* und somit von jedem zugänglich. Nach einer erfolgreichen Installation sollten auch die *XPK-Packer* erkannt werden. Bitte beachten Sie, daß die *xpkmaster.library* mit der Versionsnummer größer gleich 2 für RAP! benötigt wird, da in den ersten Versionen noch ein kleiner Fehler vorhanden war, der die Verwendung zusammen mit RAP! ausschloß.

Beachten Sie bitte, daß durch das Verfahren im *RAP!-System* die Kompressionsraten sich um einige Prozente gegenüber den angegebenen Zahlen der *XPK-Packer* verschlechtern können, da die Daten aus technischen Gründen in einzelne Bereiche vor dem Komprimieren aufgestückelt werden (ChunkGröße).




## Anhang F, Platzhalter 

In allen Pfadangaben sind sogenannte Platzhalter möglich einzugeben, wobei folgende Arten unterstützt werden:

"\*", "xx\*" sowie "\*xx".

"\*"	gilt für alle Dateien oder Verzeichnisse.  
"xx\*"	gilt für Dateien oder Verzeichnisse wie "xxtest" oder "xx" oder "xxyz".  
"\*xx"	gilt für Dateien oder Verzeichnisse wie "xx" oder "testxx" oder "zyxx".




## Anhang G, Die mitgelieferten Packer "scn1" und "runl". 

Momentan werden zwei Packer mitgeliefert, von denen eigentlich der "runl" Packer nicht verwendet werden sollte, da er nur zur Überprüfung geschrieben wurde, und in den meisten Fällen die Daten nur um sehr wenig Prozent komprimiert.

Der "scn1" ist momentan einer der schnellsten Amiga LZSS-Packer, der zwar relativ viel (ca. 180KB) Speicher beim Komprimieren benötigt, diesen aber bei der Dekomprimierung freigibt. Er hat eine ungefähre Durchschnittskompression von 40% bis 45%. Bei Textdateien fällt diese Rate etwas höher aus.





## Anhang H, Tastaturkürzel im Konfigurationsprogramm 

Da nicht alle Tastaturkürzel bei den Funktionsknöpfen mit einem Unterstrich versehen sind, finden Sie nachfolgend noch ein komplette Aufstellung der Tastaturkürzel.

Basisfenster:

`l`	Laufwerk anfügen  
`p`	Pfad anfügen  
`u`	Unterpfad anfügen

`e`	Eintrag editieren  
`a`	Eintrag aktualisieren

`c`	Block ausschneiden  
`n`	Block anfügen  
`t`	Block unter-anfügen

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

`v`	Bestätigung (Knopf am weitesten links)  
`b`	Abbruch oder OK! (Knopf am weitesten rechts)

