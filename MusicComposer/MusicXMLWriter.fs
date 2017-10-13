namespace MusicComposer

module MusicXMLWriter = 

    open System.Xml.Linq
    open System.Xml

    let private alterInNaturalScale (note:Note) (key:KeySignature) = 
        Map.find key Key.keyAlters |> Seq.contains (note.Pitch.Name, note.Pitch.Alter)

    /// Writes a sequence of measures in musicxml format (http://www.musicxml.com) to the specified file.
    let write (measures: Measure seq) (fileName:string) = 
        let version = 3
        let xn s = XName.op_Implicit s

        let measureXElement (measure:Measure) = 

            let noteXElement (note:Note) = 
                XElement(xn "note", 
                    (if note.Chord then XElement(xn "chord") else null),
                    XElement(xn "pitch", 
                        XElement(xn "step", note.Pitch.Name),
                        (if(note.Pitch.Alter <> NoteAlter.Natural) then
                            XElement(xn "alter", int note.Pitch.Alter)
                        else 
                            null),
                        XElement(xn "octave", int note.Pitch.Octave)
                    ),
                    XElement(xn "duration", int note.Duration),
                    XElement(xn "type", (string note.Duration).ToLower()),
                    if not (alterInNaturalScale note measure.Key.Signature) then 
                        XElement(xn "accidental", (string note.Pitch.Alter).ToLower())
                    else 
                        null                                                        
                )

            let keyXElement (key:Key) = 
                XElement(xn "key", 
                    XElement(xn "fifths", int key.Signature),
                    XElement(xn "mode", string key.KeyType)
                )

            XElement(xn "measure",
                XElement(xn "attributes",
                    XElement(xn "divisions", measure.DivisionsPerBeat),
                    keyXElement measure.Key,
                    XElement(xn "time", 
                        XElement(xn "beats", fst measure.Time),
                        XElement(xn "beat-type", snd measure.Time)
                    )
                ),
                seq { for note in measure.Notes -> noteXElement note},
                XAttribute(xn "number", "")
            )

        let xml = XDocument(
                    XDocumentType("score-partwise", "-//Recordare//DTD MusicXML 3.0 Partwise//EN", "http://www.musicxml.org/dtds/partwise.dtd", null),
                    XElement(xn "score-partwise",
                        XElement(xn "part-list", 
                            XElement(xn "score-part", 
                                XElement(xn "part-name", ""),
                                XAttribute(xn "id", "P1")
                            )
                        ),
                        XElement(xn "part", 
                            seq { for m in measures -> measureXElement m },
                             XAttribute(xn "id", "P1")
                        ),
                        XAttribute(xn "version", version)
                    )
                )

        use writer = XmlWriter.Create(fileName, XmlWriterSettings(Indent= true))
        xml.WriteTo(writer)