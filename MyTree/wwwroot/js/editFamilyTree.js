
const CONTAINER = document.querySelector("#familyTreeContainer");
const ADD_PERSON_MODAL = document.querySelector("#addPersonModal");

const INPUT_FIRST_NAME = document.querySelector("#inputFirstName");
const INPUT_LAST_NAME = document.querySelector("#inputLastName");

const HTTP_REQUEST = new XMLHttpRequest();
const API_URL = 'http://localhost:13475/api/People';


var personToAdd = {
	FirstName: "",
	LastName: "",
	Gender: 0
};

function GenerateTree(people)
{
	if (people.length > 0)
	{
		CONTAINER.innerHTML = ""; // Clear content

		people.forEach(person => {

			// Create the card for the person to add
			let card = document.createElement("div");
			card.setAttribute("class", "family-member card");

			// Create the overlay on top of the member card
			let cardOverlay = document.createElement("div");
			cardOverlay.setAttribute("class", "card-img-overlay d-flex justify-content-end align-items-start p-2");

			// Create the edit icon
			let editIconButton = document.createElement("button");
			editIconButton.setAttribute("class", "btn-icon btn m-0 p-0");
			editIconButton.type = "button";
			// When the edit icon is clicked, show the Add person modal with static backdrop
			editIconButton.onclick = function () {
				// TODO: Create and change this modal-call to EditPersonModal
				$(ADD_PERSON_MODAL).modal({ backdrop: "static" }); 
			};

			let editIcon = document.createElement("i"); // Create the actual icon
			editIcon.setAttribute("class", "fas fa-pen");

			// Append elements for overlay
			editIconButton.appendChild(editIcon);
			cardOverlay.appendChild(editIconButton);


			// Create the top part of the card
			let cardTop = document.createElement("div");
			cardTop.setAttribute("class", "family-member-top d-flex justify-content-center align-items-center");
			cardTop.classList.add(ConvertIntToGender(person.gender));

			let profileIcon = document.createElement("img");
			profileIcon.setAttribute("class", "icon-huge rounded-circle");
			profileIcon.src = "../images/UserIcon_default.png";

			// Append elements for card top
			cardTop.appendChild(profileIcon);


			// Create the body of the card
			let cardBody = document.createElement("div");
			cardBody.setAttribute("class", "family-member-body card-body text-nowrap");

			// Add person name to the body
			let firstName = document.createElement("h5");
			firstName.setAttribute("class", "card-title m-0");
			firstName.innerHTML = person.firstName;

			let lastName = document.createElement("h5");
			lastName.setAttribute("class", "card-title m-0");
			lastName.innerHTML = person.lastName;

			// Append elements for card body
			cardBody.appendChild(firstName);
			cardBody.appendChild(lastName);


			// Append elements to card, and card to document
			card.appendChild(cardOverlay);
			card.appendChild(cardTop);
			card.appendChild(cardBody);
			CONTAINER.appendChild(card);
		});
	}
}

function OnShowAddPersonModal()
{
	SetPersonGender("female");

	//TODO: Clear values on the input fields

}


function SetPersonGender(gender) {

	gender = gender.toLowerCase();

	var female = "female";
	var male = "male";

	if (gender === female || gender === male) {

		personToAdd.Gender = ConvertGenderToInt(gender);

		var modalHeader = $(ADD_PERSON_MODAL).find(".modal-header");

		modalHeader.removeClass(female);
		modalHeader.removeClass(male);
		modalHeader.addClass(gender);
	}
}

function ConvertIntToGender(number) {
	if (number === 1) {
		return "male";
	}

	return "female";
}

function ConvertGenderToInt(gender) {
	if (gender === "male") {
		return 1;
	}

	return 0;
}

function PersistPerson() {

	personToAdd.FirstName = INPUT_FIRST_NAME.value;
	personToAdd.LastName = INPUT_LAST_NAME.value;

	fetch(API_URL, {
		method: 'POST',
		body: JSON.stringify(personToAdd),
		headers: {
			'Content-Type': 'application/json'
		}
	}).then(function (respone) {

		if (respone.status !== 201) {
			console.log(respone.status);
			return;
		}

		$(ADD_PERSON_MODAL).modal("hide");
		location.reload(); // Reload document
		//GetPeopleAndGenerateTree();
	});
}


function GetPeopleAndGenerateTree() {

	HTTP_REQUEST.open('GET', API_URL, true);	// call the GET method in the API
	HTTP_REQUEST.onload = function () {			// Execute anon function after call to the GET method

		var data = this.response;

		// Don't parse if data has no content, as JSON can't parse it.
		if (data !== "") {
			data = JSON.parse(data);	// Convert people in the family to JSON
			GenerateTree(data);			// Generate family tree with the people
		}
	};
	HTTP_REQUEST.send();
}

/// Methods to call when script is run

$(ADD_PERSON_MODAL).on('show.bs.modal', OnShowAddPersonModal);

$(document).ready(function () {
	GetPeopleAndGenerateTree();
});