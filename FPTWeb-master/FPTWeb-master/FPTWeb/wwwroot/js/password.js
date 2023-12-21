const $password = document
    .querySelector('input');
const $toggler = document
    .querySelector('i');

const showHidePassword = () => {
    if ($password.type == 'password') {
        $password.setAttribute('type','text');
    }else{
        $password.setAttribute(
            'type',
            'password'
        );
    }


    $toggler.classList.toggle('fa-eye');
    $toggler.classList.toggle('fa-eye-slash');
};

$toggler.addEventListener(
    'click',
    showHidePassword,
)
