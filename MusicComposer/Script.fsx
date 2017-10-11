#r "System.Xml"
#r "System.Xml.Linq"

#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\Octave.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\Note.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\Key.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\Measure.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\NoteFactory.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\ChordFactory.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\DiatonicScale.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\ChromaticScale.fs"
#load @"C:\Users\YEFVOL\Documents\musiccomposer\MusicComposer\MusicXMLWriter.fs"

open MusicComposer

MusicXMLWriter.write ([ Measure((4,4), DiatonicScale.CMajor |> Seq.map (fun n -> Note(pitch = n.Pitch, duration = Duration.Eighth)))
                        Measure((2,4), Seq.append ChordFactory.CMinor ChordFactory.CMajor, Key.CMinor)
                        Measure((7,4), DiatonicScale.CMinor, Key.CMinor)
                        Measure((7,4), DiatonicScale.DMajor, Key.DMajor)
                        Measure((7,4), DiatonicScale.EMajor, Key.EMajor)
                        Measure((7,4), DiatonicScale.FMajor, Key.FMajor)
                        Measure((7,4), DiatonicScale.GMajor, Key.GMajor)
                        Measure((7,4), DiatonicScale.AMajor, Key.AMajor)
                        Measure((7,4), DiatonicScale.BMajor, Key.BMajor)
                        Measure((7,4), DiatonicScale.DMinor, Key.DMinor)
                        Measure((7,4), DiatonicScale.EMinor, Key.EMinor)
                        Measure((7,4), DiatonicScale.FMinor, Key.FMinor)
                        Measure((7,4), DiatonicScale.GMinor, Key.GMinor)
                        Measure((7,4), DiatonicScale.AMinor, Key.AMinor)
                        Measure((7,4), DiatonicScale.BMinor, Key.BMinor)
                        Measure((13, 4), ChromaticScale.CChromatic)
                      ]) @"C:\Users\YEFVOL\Documents\temp.xml"