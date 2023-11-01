let selectedProductId = 0;
let selectedProductName = "";
let selectedProductImage = "";
let selectedUnitName = "";
let basket = [];
let selectedUnitQuantity = 0.1;
function GetCategoriyList() {
    Get("Category/GetAll", (data) => {
        categories = data;
        var html = `<option selected disabled value="0">Kategori Seç...</option>`;
        for (var i = 0; i < categories.length; i++) {
            html += `<option value="${categories[i].id}">${categories[i].categoryName}</option>`;
        }
        $("#categoriyOption").html(html);
        document.getElementById("addProductButton").disabled = true;
    });
}
function CategoryChange() {
    let categoryId = document.getElementById("categoriyOption").value;
    Get(`Product/Category/${categoryId}`, (data) => {
        products = data;
        var html = `<option selected disabled value="0">Ürün Seç...</option>`;
        for (var i = 0; i < products.length; i++) {
            html += `<option value="${products[i].id}">${products[i].productName}</option>`;
        }
        $("#productImage").attr("src", "/img/null.png");
        $("#productOption").html(html);
    });
}
function GetProductListByCategoryId() {
    selectedProductId = parseInt(document.getElementById("productOption").value);

    Get(`Product/${selectedProductId}`, (data) => {
        product = data;
        $("#productImage").attr("src", "/img/" + product.productImage);
        selectedProductName = product.productName;
        selectedProductImage = product.productImage;
        selectedProductUnitId = product.unit.id;
        selectedUnitName = product.unit.unitName;
        document.getElementById("addProductButton").disabled = false;
    });
}

// İngilizce olarak düzelt
function EditProduct(productId) {

    let product = basket.find(basket => basket.ProductId === productId);
    if (product != undefined) {

        let inputName = "inputProductQuantity" + productId;
        let quantity = document.getElementById(inputName).value;
        product.ProductQuantity = parseInt(quantity);
    }
}

function ProductUnitQuantity(productId) {

    let product = basket.find(basket => basket.ProductId === productId);
    if (product != undefined) {

        let inputName = "inputProductUnitQuantity" + productId;
        let quantity = document.getElementById(inputName).value;
        product.ProductUnitQuantity = parseFloat(quantity);
    }
}
function BasketProductList() {
    if (basket.length > 0) {
        var html = `<table class="table table-hover"><tr>`;
        html += `<th>Ürün Resmi</th>`;
        html += `<th>Ürün Adı</th>`;
        html += `<th>Miktar/Birim</th>`;
        html += `<th>Adet</th>`;
        html += `<th>İşlem</th>`;

        html += `</tr>`;
        for (var i = 0; i < basket.length; i++) {
            html += `<tr>`;
            html += `<td style="justify-content-center"><img src="/img/${basket[i].ProductImage}" alt="product-img" title="product-img" class="rounded me-2" height="32"></td>`
            html += `<td>${basket[i].ProductName}</td>`;
            if (basket[i].ProductUnitId != 1) {

                html += `<td><div class="input-group" style="width:150px;">`;
                html += `    <input type="number" id="inputProductUnitQuantity${basket[i].ProductId}" class="form-control" onchange="ProductUnitQuantity(${basket[i].ProductId})" min="0" value="1" placeholder="0" style="width: 30px;">`;
                html += `    <label class="input-group-text">${basket[i].ProductUnitName}</label>`;
                html += `</div></td>`;
            }
            else {
                html += `<td></td>`;
            }
            html += `<td><input type="number" id="inputProductQuantity${basket[i].ProductId}" onchange="EditProduct(${basket[i].ProductId})" min="1" value="${parseInt(basket[i].ProductQuantity)}" class="form-control" placeholder="0" style="width: 90px;"></td>`
            html += `<td><button type="button" onclick="DeleteProduct(${basket[i].ProductId})" class="btn btn-danger mb-2 me-1">
            <span><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3" viewBox="0 0 16 16">
 <path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z"/>
</svg></span> Çıkar</button></td>`;
            html += `</tr>`
        }
        html += `</table> `;
        $("#divProductList").html(html);
        document.getElementById("createRequestButton").disabled = false;
        $("#createRequestButton").removeClass('btn-secondary');
        $("#createRequestButton").addClass('btn-success');
    }

    else {
        $("#divProductList").html("");
        document.getElementById("createRequestButton").disabled = true;
        $("#createRequestButton").removeClass('btn-success');
        $("#createRequestButton").addClass('btn-secondary');
    }
}

function ProductChange() {

    GetProductListByCategoryId();
}



function CreateRequest() {
    basket.map(function (basket) {
        delete basket.ProductImage;
        delete basket.ProductUnitName;
        delete basket.ProductName;
        return basket;
    });
    var data = {
        UserId: 1,
        Basket: basket ,
        CompanyId: 25,
    };

    Post("Basket/Kaydet", data, (data) => {

    });

}

function DeleteProduct(productId) {
    let index = basket.findIndex(basket => basket.ProductId === productId);
    basket.splice(index, 1);
    BasketProductList();
}

function AddProduct() {
    let product;
    if (basket.length > 0) {
        product = basket.find(basket => basket.ProductId === selectedProductId);

        if (product !== undefined) {
            let selectedProductQuantity = parseInt(product.ProductQuantity);
            product.ProductQuantity = selectedProductQuantity + 1;
        }
        else {
            AddNewProduct();
        }
    }
    else {

        AddNewProduct();
    }
    RefreshModal();
    BasketProductList();
}

function AddNewProduct() {

    var newProduct = {
        ProductId: selectedProductId,
        ProductName: selectedProductName,
        ProductImage: selectedProductImage,
        ProductQuantity: 1,
        ProductUnitId: selectedProductUnitId,
        ProductUnitName: selectedUnitName,
        ProductUnitQuantity: 1.0,
    };
    basket.push(newProduct);
}
function RefreshModal() {
    $("#productImage").attr("src", "/img/null.png");
    document.getElementById("addProductButton").disabled = true;
    $("#addProductModal").modal("hide");
    $('#categoriyOption option:first').prop('selected', true);
    $('#productOption option:first').prop('selected', true);
}
$(document).ready(function () {
    GetCategoriyList();
});

