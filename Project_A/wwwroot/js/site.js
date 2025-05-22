

var userId=0;
var userName="";
var phone = 0;
var email = "";
var baseURL = "https://localhost:7260";
function startOrder() {
    
    document.getElementById('name').style.display = 'block';
    document.getElementById('phon').style.display = 'block';
    document.getElementById('id').style.display = 'block'; // Show the ID input
    document.getElementById('email').style.display = 'block';
    document.getElementById('selectSize').style.display = 'block';
 
}


function UserDetails() {
     userId = document.getElementById('id').value;
     userName = document.getElementById('name').value;
    phone = document.getElementById('phon').value;
    //email = document.getElementById('email').value;
    email = "as7674404@gmail.com";
    //email.style.display = 'none';
    document.getElementById('name').style.display = 'none';
    document.getElementById('phon').style.display = 'none';
    document.getElementById('id').style.display = 'none'; // Show the ID input
    document.getElementById('email').style.display = 'none';
    document.getElementById('selectSize').style.display = 'none';
    document.getElementById('startOrderButton').style.display = 'none';
    document.getElementById('sizePopup').style.display = 'block';
}


function setSize(size) {
    document.getElementById('selectedSize').innerText = 'Selected size: ' + size;
    closePopup();


    console.log("ui", userId, "un", userName, "s", size, "ph", phone, "em", email);

    var user = {
        userId: userId,
        userName: userName,
        selectedSize: parseFloat(size), // Ensure selectedSize is a number
        phone: phone,
        email: "as7674404@gmail.com"
    };
    console.log(user);
    var raw = JSON.stringify(user);
    const requestOptions = {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: raw
    };

    fetch(`${baseURL}/Home/SubmitOrder`, requestOptions)
        .then(response => response.text())
        .then(result => console.log("📩 Server response99999999999999:", result))
        .catch(error => console.error("❌ Fetch error:", error));
}

function closePopup() {
    document.getElementById('sizePopup').style.display = 'none';
}
