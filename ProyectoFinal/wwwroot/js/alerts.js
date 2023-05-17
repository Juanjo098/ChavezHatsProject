const confirmacion = (titulo, texto, mensaje, form) => {
    Swal.fire({
        title: titulo,
        text: texto,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                mensaje
            )
            form.submit()
        }
    })
}