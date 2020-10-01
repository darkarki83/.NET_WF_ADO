"use strict"

function AnsQua(mquation, mfirst, msecond, mthert, mfour) {

    return {
        quation:mquation,
        first:mfirst,
        second:msecond,
        thert:mthert,
        four:mfour
    }
}

let ArrAnsQua = [];
ArrAnsQua.push(new AnsQua("kto boss", "1", "2", "3", "4"));
ArrAnsQua.push(new AnsQua("gde boss", "q", "w", "e", "r"));
ArrAnsQua.push(new AnsQua("kak dela", "10", "20", "30", "40"));
ArrAnsQua.push(new AnsQua("gde tyt", "tut", "tam", "kak", "zachem"));

function ArrAnsCode(mf, ms, mt, mfo) {

    return {
        f:mf,
        s:ms,
        t:mt,
        fo:mfo
    }
}

let ArrAns = [];
ArrAns.push(new ArrAnsCode(10, 11, 10, 11));
ArrAns.push(new ArrAnsCode(11, 11, 12, 12));
ArrAns.push(new ArrAnsCode(12, 13, 13, 13));
ArrAns.push(new ArrAnsCode(14, 13, 13, 13));