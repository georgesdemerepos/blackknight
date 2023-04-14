import React from "react";
import "./LoginAttemptList.css";

const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

const LoginAttemptList = (props) => {
  const [search, setSearch] = React.useState("");
  return (
    <div className="Attempt-List-Main">
      <p>Recent activity</p>
      <input
        type="input"
        placeholder="Filter..."
        value={search}
        onChange={(e) => setSearch(e.target.value)}
      />
      <ul className="Attempt-List">
        {props.attempts
          .filter((attempt) => {
            return search === ""
              ? attempt
              : attempt.login.includes(search) ||
                  attempt.password.includes(search);
          })
          .map((attempt) => (
            <LoginAttempt>
              {attempt.login} {attempt.password}
            </LoginAttempt>
          ))}
      </ul>
    </div>
  );
};

export default LoginAttemptList;
