async function changePassword() {

    const urlParams = new URLSearchParams(window.location.search);
    const token = urlParams.get('token');

    const newPassword = document.getElementById("newPassword").value;
    const confirmPassword = document.getElementById("confirmPassword").value;
    const message = document.getElementById("message");

    // Validate that passwords match
    if (newPassword !== confirmPassword) {
        message.textContent = "Passwords do not match!";
        alert("Passwords do not match!");
        return;
    }
    
    try {
        const response = await fetch('http://localhost:5160/api/passwordreset/reset-password', {
            method: 'PATCH',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ token, newPassword })
        });

        if (response.ok) {
            document.getElementById('message').textContent = "Password reset successfully!";
            alert("PASSWORD RESET SUCCESFULLY")
            setTimeout(() => {
                window.location.href = "about:blank";
                window.close(); // Fallback, may not work
            }, 2000);
        } else {
            const errorText = await response.text();
            document.getElementById('message').textContent = `Error: ${errorText}`;
            let errorDisplay = `Error: ${errorText}`
            alert(errorDisplay)
        }
    } catch (error) {
        document.getElementById('message').textContent = `Error: ${error.message}`;
    }
}