var Navigator = {
    navigate: function (destination, controller) {
        window.location.href = `${baseUrl}/${controller}/${destination}`;
    }
}

var ValueSaver = {
    save: function (name, updateImage) {
        document.getElementById('span-category').innerHTML = name;

        //only for delete product page
        var image = document.querySelector('.trash-styling');
        if (document.getElementById('span-category').innerHTML != "Product Dropdown") {
            image.classList.remove("trash-invalid");
            image.classList.add("trash-valid");
        }
    }
}

var SendData = {
    sendProductInfo: function () {
        $.ajax({
            url: `${baseUrl}/Product/SaveProduct`,
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
    },

    sendDeleteProductInfo: function () {
        $.ajax({
            url: `${baseUrl}/Product/DeleteProductMethod`,
            contentType: "application/json",
            method: "post",
            data: JSON.stringify({
                ProductName: document.getElementById("span-category").innerHTML
            })
        }).done(function (result) {
            window.location.href = `${baseUrl}/Home/Index`;
            console.log("Boooking Saved Successfully.");
        }).fail(function (e) {
            console.log(e);
        });
    }
}

var ObjectSender = {
    sendCategoryInfo: function () {
        var element = document.getElementById("span-category").innerText;
        $.ajax({
            url: `${baseUrl}/Product/FilterDeletionByCategory`,
            contentType: "application/json",
            method: "post",
            data: JSON.stringify({
                CategoryName: element
            })
        }).done(function (result) {
            console.log("Boooking Saved Successfully.");
        }).fail(function (e) {
            console.log(e);
        });
    },
    filter: function () {
        $.ajax({
            url: `${baseUrl}/Product/ProductList`,
            contentType: "application/json",
            method: "post",
            data: JSON.stringify({
                ProductName: document.querySelector('.input-styling-search').value
            })
        }).done(function (result) {
            console.log("Boooking Saved Successfully.");
        }).fail(function (e) {
            console.log(e);
        });
    }

}

var SearchBarManager = {
    toggleSearchBar: function () {
        var input = document.querySelector(".input-styling-search");
        input.classList.toggle("input-styling-expanded");

        var icon = document.querySelector(".search-icon");
        icon.classList.toggle("search-icon-expanded");
    }
};




