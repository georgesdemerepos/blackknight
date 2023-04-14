import React from "react";
import "./LoginForm.css";

const LoginForm = (props) => {
  const [state, setState] = React.useState({ login: "", password: "" });
  const handleSubmit = (event) => {
    event.preventDefault();
    props.onSubmit({
      login: state.login,
      password: state.password,
    });
  };

  return (
    <form className="form">
      <h1>Login</h1>
      <label htmlFor="name">Name</label>
      <input
        type="text"
        id="name"
        onChange={(e) => setState({ ...state, login: e.target.value })}
      />
      <label htmlFor="password">Password</label>
      <input
        type="password"
        id="password"
        onChange={(e) => setState({ ...state, password: e.target.value })}
      />
      <button type="submit" onClick={handleSubmit}>
        Continue
      </button>
    </form>
  );
};

export default LoginForm;
