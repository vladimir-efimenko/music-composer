namespace MusicComposer

module MusicXMLWriter = 

    open System.Xml.Linq
    open System.Xml

    // let private noteAlterInKey alter key = 


    let write (measures: Measure seq) (fileName:string) = 
        let version = 3
        let xn s = XName.op_Implicit s

        let noteXElement (note:Note) = 
            new XElement(xn "note", 
                (if note.Chord then XElement(xn "chord") else null),
                new XElement(xn "pitch", 
                    new XElement(xn "step", note.Pitch.Name),
                    (if(note.Pitch.Alter <> NoteAlter.Natural) then
                        new XElement(xn "alter", int note.Pitch.Alter)
                    else 
                        null),
                    new XElement(xn "octave", int note.Pitch.Octave)
                ),
                new XElement(xn "duration", int note.Duration),
                new XElement(xn "type", (string note.Duration).ToLower()),
                if(note.Pitch.Alter <> NoteAlter.Natural) then 
                    new XElement(xn "accidental", (string note.Pitch.Alter).ToLower())
                else 
                    null                                                        
            )

        let keyXElement (key:Key) = 
            new XElement(xn "key", 
                new XElement(xn "fifths", key.AlterNumber),
                new XElement(xn "mode", string key.KeyType)
            )
        
        let measureXElement (measure:Measure) = 
            new XElement(xn "measure",
                new XElement(xn "attributes",
                    new XElement(xn "divisions", measure.DivisionsPerBeat),
                    keyXElement measure.Key,
                    new XElement(xn "time", 
                        new XElement(xn "beats", fst measure.Time),
                        new XElement(xn "beat-type", snd measure.Time)
                    )
                ),
                seq { for note in measure.Notes -> noteXElement note},
                new XAttribute(xn "number", "")
            )

        let xml = new XDocument(
                    new XDocumentType("score-partwise", "-//Recordare//DTD MusicXML 3.0 Partwise//EN", "http://www.musicxml.org/dtds/partwise.dtd", null),
                    new XElement(xn "score-partwise",
                        new XElement(xn "part-list", 
                            new XElement(xn "score-part", 
                                new XElement(xn "part-name", ""),
                                new XAttribute(xn "id", "P1")
                            )
                        ),
                        new XElement(xn "part", 
                            seq { for m in measures -> measureXElement m },
                             new XAttribute(xn "id", "P1")
                        ),
                        new XAttribute(xn "version", version)
                    )
                )

        use writer = XmlWriter.Create(fileName, XmlWriterSettings(Indent= true))
        xml.WriteTo(writer)