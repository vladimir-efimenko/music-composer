﻿namespace MusicComposer

// The time signature has two numbers, one above the other,
// and appears at the beginning of the first line of music.
type Time = int*int

type Measure = 
    val Time:Time
    val DivisionsPerBeat:int
    val Notes:Note seq
    val Key:Key
    new (time:Time, notes: Note seq) = 
        { Time = time; Notes = notes; DivisionsPerBeat = 48; Key = Key(KeySignature.C, KeyType.Major) }
    new (time:Time, divisions: int, notes: Note seq) = 
        { Time = time; Notes = notes; DivisionsPerBeat = divisions; Key = Key(KeySignature.C, KeyType.Major) }
    new (time:Time, divisions: int, notes: Note seq, key: Key) = 
        { Time = time; Notes = notes; DivisionsPerBeat = divisions; Key = key }
    new (time:Time, notes: Note seq, key: Key) = 
        { Time = time; Notes = notes; DivisionsPerBeat = 48; Key = key }