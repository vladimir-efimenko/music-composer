namespace MusicComposer

module MusicXMLReader = 
    open System.Xml.Linq
    open System.Linq

    /// Reads a file in musicXML format
    let read (fileName:string) = 

        let xn s = XName.op_Implicit s

        let doc = XDocument.Load(fileName)
        let part = doc.Root.Element(xn "part-list").Element(xn "score-part")
        let piece = Piece(part.Element(xn "part-name").Value)
        
        let measuresEl = doc.Root.Elements(xn "part").First(fun el -> 
            el.Attribute(xn "id").Value = part.Attribute(xn "id").Value).Elements(xn "measure")
        
        let readMeasure (m:XElement) = 
            let attrs = m.Elements(xn "attributes")
            let time = attrs.Elements(xn "time").First()
            Measure((time.Element(xn "beats").Value |> int, time.Element(xn "beat-type").Value |> int), attrs.Elements(xn "divisions").First().Value |> int, notes=[])

        piece.Measures.AddRange(measuresEl |> Seq.map readMeasure)

        piece