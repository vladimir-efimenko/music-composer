#r "System.Xml"
#r "System.Xml.Linq"

#load @"D:\Development\MusicComposer\MusicComposer\Octave.fs"
#load @"D:\Development\MusicComposer\MusicComposer\Note.fs"
#load @"D:\Development\MusicComposer\MusicComposer\Key.fs"
#load @"D:\Development\MusicComposer\MusicComposer\Measure.fs"
#load @"D:\Development\MusicComposer\MusicComposer\NoteFactory.fs"
#load @"D:\Development\MusicComposer\MusicComposer\DiatonicScale.fs"
#load @"D:\Development\MusicComposer\MusicComposer\ChromaticScale.fs"
#load @"D:\Development\MusicComposer\MusicComposer\ChordFactory.fs"
#load @"D:\Development\MusicComposer\MusicComposer\MusicXMLWriter.fs"

open MusicComposer

MusicXMLWriter.write ([ Measure((4,4), DiatonicScale.CMajor |> Seq.map (fun n -> n.WithDuration(Duration.Eighth)))
                        Measure((2,4), Seq.append ChordFactory.CMinor ChordFactory.CMajor, Key.CMinor)
                        Measure((1, 4), ChordFactory.DMajor)
                        Measure((1, 4), ChordFactory.DMinor)
                        Measure((1, 4), ChordFactory.EMajor)
                        Measure((1, 4), ChordFactory.EMinor)
                        Measure((1, 4), ChordFactory.FMajor)
                        Measure((1, 4), ChordFactory.FMinor)
                        Measure((1, 4), ChordFactory.GMajor)
                        Measure((1, 4), ChordFactory.GMinor)
                        Measure((1, 4), ChordFactory.AMajor)
                        Measure((1, 4), ChordFactory.AMinor)
                        Measure((1, 4), ChordFactory.BMajor)
                        Measure((1, 4), ChordFactory.BMinor)

                        Measure((8,4), DiatonicScale.CMinor, Key.CMinor)
                        Measure((8,4), DiatonicScale.DMajor, Key.DMajor)
                        Measure((8,4), DiatonicScale.EMajor, Key.EMajor)
                        Measure((8,4), DiatonicScale.FMajor, Key.FMajor)
                        Measure((8,4), DiatonicScale.GMajor, Key.GMajor)
                        Measure((8,4), DiatonicScale.AMajor, Key.AMajor)
                        Measure((8,4), DiatonicScale.BMajor, Key.BMajor)
                        Measure((8,4), DiatonicScale.DMinor, Key.DMinor)
                        Measure((8,4), DiatonicScale.EMinor, Key.EMinor)
                        Measure((8,4), DiatonicScale.FMinor, Key.FMinor)
                        Measure((8,4), DiatonicScale.GMinor, Key.GMinor)
                        Measure((8,4), DiatonicScale.AMinor, Key.AMinor)
                        Measure((8,4), DiatonicScale.BMinor, Key.BMinor)
                        Measure((13, 4), ChromaticScale.CChromaticAscending)
                        Measure((13, 4), ChromaticScale.CChromaticDescending)
                        Measure((4,4), seq { 
                                yield! ChordFactory.tonic DiatonicScale.CMajor
                                yield! ChordFactory.subdominant DiatonicScale.CMajor
                                yield! ChordFactory.dominant DiatonicScale.CMajor
                                yield! ChordFactory.tonic DiatonicScale.CMajor |> Seq.map ( fun note -> note.AddOctave())

                            }, Key.CMajor )
                      ]) @"d:\temp.xml"

