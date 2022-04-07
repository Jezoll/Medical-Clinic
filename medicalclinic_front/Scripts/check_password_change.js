const btn = document.querySelector('#Button1');
const btnCancel = document.querySelector('#returnBtn');
const pass = document.querySelector('#new_passw');
const confirmPass = document.querySelector('#confirm_passw');
const popup = document.querySelector('.popup');

const handleCancelBtn = e => {
    e.preventDefault();

    if (confirm('Czy na pewno chcesz opuścić ten formularz'))
        window.location.href = 'Login.aspx';
    else
        [pass, confirmPass].forEach(el => el.value = '');
}

const checkPassword = (pass1, pass2) => {
    const re = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,15}$/;

    if (re.test(pass1.value) || re.test(pass2.value))
        if (pass1.value === pass2.value) {
            btn.classList.remove('change-password')
            return true;
        }
        else {
            btn.classList.add('change-password');
            return false;
        }
}

const handleSubmitBtn = e => {
    e.preventDefault();
    if (checkPassword(pass, confirmPass))
        popup.style.display = 'block'
}

[pass, confirmPass].forEach(el => el.addEventListener('keyup', function () {
    checkPassword(pass, confirmPass)
}))

btn.addEventListener('click', handleSubmitBtn)
btnCancel.addEventListener('click', handleCancelBtn)