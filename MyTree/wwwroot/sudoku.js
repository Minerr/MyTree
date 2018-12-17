// Sudoku JavaScript

const SUDOKU_PICKER = document.querySelector("#SudokuPicker");
const BOARD = document.querySelector(".Board");
const A_BOARDS = [
  "000400070-060100020-012009040-001630008-000207000-2000841000-90500280-040009070-060008000",
  "004600000-090080000-826094000-010060003-030502060-200030050-000430198-000020040-000009500",
  "000050260-008620700-900048100-100003090-080060030-060800004-002480009-005072800-083010000",
  "000000013-000009070-060074802-000001700-907268403-003400000-508640020-040800000-120000000",
  "208040930-000100874-000063025-000000020-540000098-070000000-590360000-413002000-087050302",
  "025908040-060000009-001400003-200050000-050697030-000040008-300001400-200000010-010306890",
  "000000060-080059000-300801025-000890304-000321000-203076000-210507009-000290010-050000000",
  "700010009-400500020-002700008-860000400-005000300-003000076-600007100-080003004-900060007"
];

function GenerateBoard() {


  let i;
  for(i = 1; i <= A_BOARDS.length; i++) // Fill the picker with each sudoku from the array.
  {
    let optionElement = document.createElement("option");
    optionElement.value = i;
    optionElement.innerHTML = "Sudoku #" + (("00" + i).slice (-3));

    SUDOKU_PICKER.appendChild(optionElement);
  }


  var randomNumber = GetRandomInt(0, A_BOARDS.length - 1);
  SUDOKU_PICKER.value = randomNumber + 1;
  DrawBoard(A_BOARDS[randomNumber]);
}

function PickBoard(e) {
  boardNumber = e.target.value;

  DrawBoard(A_BOARDS[boardNumber - 1]);
}

function DrawBoard(seed) {
  BOARD.innerHTML = "";
  // remove all '-' from the seed string
  seed = seed.replace(/-/g,"");

  let fieldIter;
  for(fieldIter = 1; fieldIter <= 9; fieldIter++)
  {
    // The sudoku field contains 9 large number fields.
    let field = document.createElement("div");
    field.id = guidGenerator();
    field.classList.add("Field");
    field.classList.add(GetVerticalPosition(fieldIter));
    field.classList.add(GetHorizontalPosition(fieldIter));

    let largeNumberIter;
    for(largeNumberIter = 1; largeNumberIter <= 9; largeNumberIter++)
    {
      // get the current large number from the seed
      let currentSeedNumber = seed[(9 * (fieldIter - 1)) + (largeNumberIter - 1)];

      // This element is for displaying the large number from the seed
      let largeNumber = document.createElement("div");
      largeNumber.id = guidGenerator();
      largeNumber.classList.add("LargeNumber");
      largeNumber.classList.add(GetVerticalPosition(largeNumberIter));
      largeNumber.classList.add(GetHorizontalPosition(largeNumberIter));

      // if the sudoku field does not have a number, display helper numbers instead.
      if(currentSeedNumber == "0") {

        let smallNumberIter;
        for(smallNumberIter = 1; smallNumberIter <= 9; smallNumberIter++)
        {
          // this element is for displaying each helper numbers
          let smallNumber = document.createElement("div");
          smallNumber.id = guidGenerator();
          smallNumber.classList.add("SmallNumber");
          smallNumber.classList.add(GetVerticalPosition(smallNumberIter));
          smallNumber.classList.add(GetHorizontalPosition(smallNumberIter));

          // Display current helper number
          let currentSmallNumber = document.createTextNode(smallNumberIter);
          smallNumber.appendChild(currentSmallNumber);

          // Add event when left and right clicking on the helper number
          smallNumber.onmousedown = SmallNumberOnMouseDown;

          // Append current helper number to the large number field
          largeNumber.appendChild(smallNumber);
        }
      }
      else { // if the large number from the seed is a number, display it.
        let largeNumberElement = document.createElement("p");
        let seedNumber = document.createTextNode(currentSeedNumber);
        largeNumberElement.appendChild(seedNumber);
        largeNumber.appendChild(largeNumberElement);
      }

      // append the large number to the current field
      field.appendChild(largeNumber);
    }

    // append the current field to the board
    BOARD.appendChild(field);
  }
}

function guidGenerator() {
    var S4 = function() {
       return (((1+Math.random())*0x10000)|0).toString(16).substring(1);
    };
    return "UUID-" + (S4()+S4()+"-"+S4()+"-"+S4()+"-"+S4()+"-"+S4()+S4()+S4());
}

function GetHorizontalPosition(number) {

  // if(number == 0 || number == 3 || number == 6)
  let result = "L";

  if(number == 2 || number == 5 || number == 8)
  {
    result = "C";
  }
  else if(number == 3 || number == 6 || number == 9)
  {
    result = "R";
  }

  return result;
}

function GetVerticalPosition(number) {
  let result = "T";

  if(number > 3 && number <= 6)
  {
    result = "M";
  }
  else if(number > 6)
  {
    result = "B";
  }

  return result;
}

function SmallNumberOnMouseDown(e) {
  var element = e.target;

  // check for left click
  if(e.button === 0) {
    element.classList.toggle("Clicked");
    element.classList.remove("Marked");
  }
  else if(e.button === 1) { // check for middle click
    element.classList.toggle("Marked");
    element.classList.remove("Clicked");
  }
  else if(e.button === 2) { // check for right click
    ChooseLargeNumber(element);
  }
}

function ChooseLargeNumber(smallNumber) {
  var largeNumber = smallNumber.parentNode;

  let i;
  for(i = 0; i < largeNumber.childNodes.length; i++)
  {
    largeNumber.childNodes[i].style.display = "none";
  }

  // Create paragraph with the chosen smallNumber and append it to the largeNumber
  let chosenNumber = document.createElement("p");
  chosenNumber.appendChild(document.createTextNode(smallNumber.innerHTML));

  largeNumber.classList.toggle("Chosen");
  chosenNumber.onmousedown = RemoveLargeNumber;
  largeNumber.appendChild(chosenNumber);
}

function RemoveLargeNumber(e) {
  var largeNumber = e.target.parentNode;

  let i;
  for(i = 0; i < largeNumber.childNodes.length; i++)
  {
    largeNumber.childNodes[i].style.display = "block";
  }

  document.querySelector("#" + largeNumber.id + ".Chosen p").remove();
  largeNumber.classList.toggle("Chosen");
}

function GetRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

window.onload = GenerateBoard();
SUDOKU_PICKER.onchange = PickBoard;
