<template>
  <div class="base container-fluid">
    <div id="login" class="text-center login mx-auto">
      <form class="form-signin form" @submit.prevent="login">
        <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
        <div
          class="alert alert-danger"
          role="alert"
          v-if="invalidCredentials"
        >Invalid username and password!</div>
        <div
          class="alert alert-success"
          role="alert"
          v-if="this.$route.query.registration"
        >Thank you for registering, please sign in.</div>

        <input
          type="text"
          id="username"
          class="form-control"
          placeholder="Username"
          v-model="user.username"
          required
          autofocus
        />

        <input
          type="password"
          id="password"
          class="form-control"
          placeholder="Password"
          v-model="user.password"
          required
        />
        <router-link :to="{ name: 'register' }" id="needAccount">Need an account?</router-link>
        <button type="submit" class="btn btn-sm btn-primary btn-block center">Sign in</button>
      </form>
    </div>
  </div>
</template>

<script>
import auth from "../auth";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/login`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.user)
      })
        .then(response => {
          if (response.ok) {
            return response.text();
          } else {
            this.invalidCredentials = true;
          }
        })
        .then(token => {
          if (token != undefined) {
            if (token.includes('"')) {
              token = token.replace(/"/g, "");
            }
            auth.saveToken(token);
            this.$router.push("/");
          }
        })
        .catch(err => console.error(err));
    }
  }
};
</script>

<style scoped>
.login {
  color: white;
  font-weight: bolder;
  background-color: rgba(100, 100, 100, .9);
  text-align: center;
  align-content: center;
  overflow-y:auto;
  max-width: 400px;
}
.form-signin {
  margin: auto;
}
.base {
  width: 100vw;
  height: 100vh;
  background-size: cover;
  overflow: hidden;
  /* position: fixed; */
  top: 1;
  left: 0;
  /* background-attachment: fixed; */
  min-width: 100%;
  min-height: 100%;
  background-image: url("../assets/2.jpg");
  background-attachment: fixed;
  overflow-y:auto;
  padding: 50px
}
@media only screen and (min-width: 1079px) {
  .base {
    position: fixed;
  }
}
.btn {
  width: 30%;
  position: inherit;
  margin-bottom: 10px;
  margin-top: 5px;
}
.center {
  margin-left: 35%;
  margin-right: 35%;
}
#username {
  margin-bottom: 10px;
}
#password {
  margin-bottom: 5px;
}
</style>
