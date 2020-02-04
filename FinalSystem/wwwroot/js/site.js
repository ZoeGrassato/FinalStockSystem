var Navigator = {
    navigate: function (destination) {
        window.location.href = `${baseUrl}/Home/${destination}`;
    }
}

var ValueSaver = {
    save: function (name) {
        document.getElementById('span-category').innerHTML = name;
    }
}

var SendData = {
    send: function () {
        $.ajax({
            url: `${baseUrl}/Home/SaveProduct`,
            contentType: "application/json",
            method: "post",
            data: JSON.stringify({
                Name: document.getElementById("Name").value,
                CategoryName: document.getElementById('span-category').innerHTML,
                Price: document.getElementById("Price").value,
                Description: document.getElementById("Description").value
            })
        }).done(function () {
            console.log("Boooking Saved Successfully.");
        }).fail(function (e) {
            console.log(e);
        });
    }
}