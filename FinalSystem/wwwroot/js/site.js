var Navigator = {
    navigate: function (destination, controller) {
        window.location.href = `${baseUrl}/${controller}/${destination}`;
    }
};

var ValueSaver = {
    save: function (name) {
        document.getElementById('span-category').innerHTML = name;
    }
};


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
            window.location.href = `${baseUrl}/Home/Add`;
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
    },

    sendEditProductInfo() {
        $.ajax({
            url: `${baseUrl}/Product/EditProduct`,
            contentType: "application/json",
            method: "post",
            data: JSON.stringify({
                Name: document.getElementById("Name").value,
                CategoryName: document.getElementById('span-category').innerHTML,
                Price: document.getElementById("Price").value,
                Description: document.getElementById("Description").value
            })
        }).done(function () {
            window.location.href = `${baseUrl}/Home/Add`;
            console.log("Boooking Saved Successfully.");
        }).fail(function (e) {
            console.log(e);
        });
    }
};

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

var myThing = [];

localStorage["SomeKey"] = JSON.stringify(myThing);

//var HistoryManager = {
//    manage: function () {
//        var current = document.querySelector(".input-styling-search").value;

//        var stored = localStorage["SomeKey"];
//        var object = JSON.parse(stored);
//        object.push(current);
//        localStorage["SomeKey"] = JSON.stringify(object);
        
//        for (var i = 0; i < object.length; i++) {
//            var localThing = object[i];
//            $(`<li>${localThing}</li>`).appendTo("#myList");
//        }
//    }
//}

var Remover = {
    removeProduct: function (id) {
        //var stored = document.getElementById("hiddenId").innerHTML;
        $.ajax({
            url: `${baseUrl}/Product/DeleteProductFromDb`,
            contentType: "application/json",
            method: "post",
            data: JSON.stringify({
                //Id: parseInt(document.getElementById("hiddenId").innerHTML)
                Id: id
            })
        }).done(function () {
            window.location.href = `${baseUrl}/Home/Delete`;
        }).fail(function (e) {
            console.log(e);
        });
    },
    removeCategory: function (id) {
        var stored = document.getElementById("IdHiddenCategory").innerHTML;
        $.ajax({
            url: `${baseUrl}/ProductCategory/DeleteProductCategoryFromDb`,
            contentType: "application/json",
            method: "post",
            data: JSON.stringify({
                //Id: parseInt(document.getElementById("IdHiddenCategory").innerHTML)
                Id: id
            })
        }).done(function () {
            window.location.href = `${baseUrl}/Home/Delete`;
        }).fail(function (e) {
            console.log(e);
        });
    }
}




