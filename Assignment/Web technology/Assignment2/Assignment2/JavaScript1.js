
function Triangle() {

    var a = 5;
    var b = 10;
    var c = 7;
    var val = a + b + c / 2;
    var area = Math.sqrt(val * (val - a) * (val - b) * (val - c));

    console.log("Area Of Triangle: " + area);
}


function Pattern() {

    console.log("Pattern");
    for (var i = 1; i <= 5; i++) {
        var star = " ";
        for (var j = 1; j <= i; j++) {
            star += "*";
        }
        console.log(star);
    }
}


function Leapyear() {
    var year = 2000;
    if ((year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0)) {
        console.log(year + " is a Leap Year");
    }
    else {
        console.log(year + "is Not a Leap Year");
    }
}


function Dates_cal() {
    var today = new Date();
    var currentyear = today.getFullYear();
    var independenceDay = new Date(currentyear, 7, 15);
    if (today > independenceDay) {
        independenceDay = new Date(currentyear + 1, 7, 15);
    }
    var diff = independenceDay - today;
    var daysleft = Math.ceil(diff / (1000 * 60 * 60 * 24));
    console.log(daysleft + " Days left for the Independence Day!!!");
}
