const detalles = (id) => {
    document.getElementById('idDetalles').value = id
    //console.log(document.getElementById('idDetalles').value)
    document.getElementById('formDetalles').submit()
}

const editar = (id) => {
    document.getElementById('idEditar').value = id
    document.getElementById('formEditar').submit()
}

const limpiar = () => {
    document.getElementById('busqueda').value = ""
    document.getElementById('formBuscar').submit()
}

const lista = () => {
    document.getElementById('formBuscar').submit()
}

