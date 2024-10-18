document.addEventListener("DOMContentLoaded", () => {
  const form = document.getElementById("auth-form");
  const formTitle = document.getElementById("form-title");
  const toggleLink = document.getElementById("toggle-link");
  let isSignUp = true;

  toggleLink.addEventListener("click", () => {
    isSignUp = !isSignUp;
    formTitle.textContent = isSignUp ? "Sign Up" : "Login";
    form.querySelector("button").textContent = isSignUp ? "Sign Up" : "Login";
    toggleLink.textContent = isSignUp
      ? "Already have an account? Login"
      : "Don't have an account? Sign Up";
  });

  form.addEventListener("submit", (event) => {
    event.preventDefault();

    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    if (username === "" || password === "") {
      alert("Please fill in both fields.");
      return;
    }

    if (isSignUp) {
      // Save username and password to local storage
      localStorage.setItem("username", username);
      localStorage.setItem("password", password);
      alert("Sign Up successful! You can now login.");
    } else {
      // Validate login credentials
      const storedUsername = localStorage.getItem("username");
      const storedPassword = localStorage.getItem("password");

      if (username === storedUsername && password === storedPassword) {
        alert("Login successful!");
      } else {
        alert("Invalid username or password.");
      }
    }
  });
});
