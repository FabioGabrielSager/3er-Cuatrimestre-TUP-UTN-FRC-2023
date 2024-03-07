class Producto{
    constructor(codigo, nombre, precio, stock){
        this.codigo = codigo;
        this.nombre = nombre;
        this.precio = precio;
        this.stock = stock;
    }
}

let productos = [new Producto("C001", "Castañas de caju",150,100), 
new Producto("C002", "Nuez",200,200), new Producto("C003", "Pistacho",500,150),
new Producto("C004", "Mani",100,100), new Producto("C005", "Almendra",125,500),
new Producto("C006", "Avellana",180,350)]

let carrito = []

function renderizarProductos(listaProductos){
    productos.sort((a, b) => {
        const nameA = a.nombre.toUpperCase();
        const nameB = b.nombre.toUpperCase();
        if (nameA < nameB) {
          return -1;
        }
        if (nameA > nameB) {
          return 1;
        }
        return 0;
      });
      
    $('#listado .row').empty();
    listaProductos.forEach((producto) =>  {
        const card = $('<div class="card ms-3 mt-2" style="width: 18rem;">');
        const cardBody = $('<div class="card-body">');
        const cardTitle = $('<h5 class="card-title">' + producto.nombre + '</h5>');
        const cardSubtitle = $('<h6 class="card-subtitle mb-2 text-body-secondary">Precio: ' + producto.precio + '</h6>');
        const cardText = $('<p class="card-text">Stock: ' + producto.stock + '</p>');
        const addButton = $('<button class="btn btn-primary">+</button>');
        addButton.on('click', function(event) {
            agregarProductoACarrito(producto);
        });
        cardBody.append(cardTitle, cardSubtitle, cardText, addButton);
        card.append(cardBody);
        $('#listado .row').append(card);
    })
}

function agregarProductoACarrito(producto){
    $('#modal-elegir-cantidad .modal-dialog .modal-content .modal-header .modal-title').text('Agregar ' + producto.nombre + ' al carrito');
    $('#modal-elegir-cantidad .modal-dialog .modal-content .modal-body .input #unidadesInput').val(1);
    $('#modal-elegir-cantidad .modal-dialog .modal-content .modal-body .input #unidadesInput').attr('max', producto.stock);
    $('#modal-elegir-cantidad .modal-dialog .modal-content .modal-footer #agregarAlCarritoBtn').text("Agregar")
    $('#modal-elegir-cantidad').modal('show');
    $('#agregarAlCarritoBtn').off('click');
    $('#agregarAlCarritoBtn').on('click', function() {
        let unidades = parseInt($('#modal-elegir-cantidad .modal-dialog .modal-content .modal-body .input #unidadesInput').val());
        $('#modal-elegir-cantidad').modal('hide');
        productos.forEach((productoEnCatalogo) => {
            if(productoEnCatalogo.codigo == producto.codigo)
                productoEnCatalogo.stock -= unidades;
                if(productoEnCatalogo.stock <= 0)
                    productos.splice(productos.indexOf(producto), 1);
        });
    
        const indiceProductoEnCarrito = carrito.findIndex(p => p.codigo === producto.codigo);
      
        if (indiceProductoEnCarrito >= 0) {
            carrito[indiceProductoEnCarrito].unidades += unidades;
        } 
        else {
            carrito.push({
            codigo: producto.codigo,
            nombre: producto.nombre,
            precio: producto.precio,
            unidades: unidades
        });
      }
        renderizarProductos(productos);
        renderizarCarrito(carrito);
    });
  
}

function renderizarCarrito(listaProductosEncarrito){
    $('#carrito .row').empty();
    carrito.forEach((producto) =>{
        const card = $('<div class="card ms-3 mt-2" style="width: 18rem;">');
        const cardBody = $('<div class="card-body">');
        const cardTitle = $('<h5 class="card-title">' + producto.nombre + '</h5>');
        const cardSubtitle = $('<h6 class="card-subtitle mb-2 text-body-secondary">Precio: ' + producto.precio + '</h6>');
        const cardText = $('<p class="card-text">Unidades: ' + producto.unidades + '</p>');
        const addButton = $('<button class="btn btn-danger">x</button>');
        addButton.on('click', function(event) {
            eliminarProductoDeCarrito(producto);
        });
        cardBody.append(cardTitle, cardSubtitle, cardText, addButton);
        card.append(cardBody);
        $('#carrito .row').append(card);
    });
    $('#carrito b').text("Total: $" + calcularTotal());
}

function eliminarProductoDeCarrito(producto){
    $('#modal-elegir-cantidad .modal-dialog .modal-content .modal-header .modal-title').text('Eliminar ' + producto.nombre + ' del carrito');
    $('#modal-elegir-cantidad .modal-dialog .modal-content .modal-body .input #unidadesInput').val(1);
    $('#modal-elegir-cantidad .modal-dialog .modal-content .modal-body .input #unidadesInput').attr('max', producto.unidades);
    $('#modal-elegir-cantidad .modal-dialog .modal-content .modal-footer #agregarAlCarritoBtn').text("Eliminar")
    $('#modal-elegir-cantidad').modal('show');
    $('#agregarAlCarritoBtn').off('click');
    $('#agregarAlCarritoBtn').on('click', function() {
        let unidades = parseInt($('#modal-elegir-cantidad .modal-dialog .modal-content .modal-body .input #unidadesInput').val());
        $('#modal-elegir-cantidad').modal('hide');
        carrito.forEach((productoEnCarrito) => {
            if(productoEnCarrito.codigo == producto.codigo)
                productoEnCarrito.unidades -= unidades;
                if(productoEnCarrito.unidades <= 0)
                    carrito.splice(carrito.indexOf(producto), 1);
        });
    
        const indiceProductoEnCatalogo = productos.findIndex(p => p.codigo === producto.codigo);
      
        if (indiceProductoEnCatalogo >= 0) {
            productos[indiceProductoEnCatalogo].stock += unidades;
        } 
        else {
            productos.push(new Producto(producto.codigo, producto.nombre, producto.precio, unidades));
      }
        renderizarProductos(productos);
        renderizarCarrito(carrito);
    });
}
function calcularTotal(){
    let total = 0;
    carrito.forEach((producto) => {
        total += producto.precio * producto.unidades;
    });

    return total;
}

function configurarBotones(){
    const botones = document.getElementsByClassName("botones-principales");
    const botonMostrarCatalogo = botones.item(0); 
    const botonMostrarCarrito = botones.item(1);
    const botonAgregarProducto = botones.item(2);

    const catalogo = document.getElementById("listado");
    const carrito = document.getElementById("carrito");
    const formulario = document.getElementById("contenedor-formulario");

    botonMostrarCatalogo.addEventListener('click', ()=>{
        if(catalogo.style.display == 'none'){
            catalogo.style.display = 'block';
            formulario.style.display = 'none';
        }
        else {
            catalogo.style.display = 'none';
        }
    })

    botonMostrarCarrito.addEventListener('click', ()=>{
        if(carrito.style.display == 'none'){
            carrito.style.display = 'block';
            formulario.style.display = 'none';
        }
        else {
            carrito.style.display = 'none';
        }
    })

    botonAgregarProducto.addEventListener('click', ()=>{
        if(formulario.style.display == 'none'){
            formulario.style.display = 'block';
            catalogo.style.display = 'none';
            carrito.style.display = 'none';
        }
        else {
            formulario.style.display = 'none';
        }
    },
    )
}

// Validaciones
$(document).ready(() => {
    $('#formulario').validate({
        rules:{
            codigo: "required",
            nombre: "required",
            precio: {
                "required": true,
                "number":true,
                "min": 1
            },
            stock: {
                "required": true,
                "number":true
            }
        },
        messages: {
            codigo: {required: "Debe ingresar un código para el producto"},
            nombre: {required: "Debe ingresar un nombre de producto"},
            precio: {
                required: "Debe ingresar precio para el producto",
                number: "Debe ingresar un precio en un formato valido",
                min: "El precio no puede ser menor a 1"},
            stock: {
                required: "Debe agregar como minimo un producto",
                min: "Debe agregar como minimo un producto",
                number: "Debe ingresar el stock con un numero enetero"
            }
        },
        errorClass: 'error-message'
    })

    $('#formulario').submit(function(event) {
        // Evitar que el formulario se envíe de forma predeterminada
        event.preventDefault();
    
        // Realizar acciones después del envío del formulario
        // Aquí puedes agregar tu lógica para saber que se está enviando
    
        // Ejemplo: Mostrar un mensaje de éxito
        alert('El formulario se ha enviado');
    });
    
});

$('#agregarProductoNuevo').click((event) => {
    event.preventDefault();
    if($('#formulario').valid()){
        const codigo = $('#codigo').val();
        const nombre = $('#nombre').val();
        const precio = parseFloat($('#precio').val());
        const stock = parseInt($('#stock').val());

        if(productos.some(p => p.codigo === codigo)){
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Ese código ya existe, por favor seleccione otro'
            });
            return;
        }

        const productoNuevo = new Producto(codigo, nombre, precio, stock);
        productos.push(productoNuevo);

        renderizarProductos(productos);
        // Limpio formulario
        $('#formulario')[0].reset();
        $('#formulario').submit();
    }
})


addEventListener("DOMContentLoaded", (event) => {renderizarProductos(productos); configurarBotones();});
