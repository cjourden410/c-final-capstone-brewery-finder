<template>
<div class="base">
  <div class="register mx-auto">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        There were problems registering this user.
      </div>
      <div class="drew">
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      </div>
      <div class="drew">
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      </div>
      <div class="drew">
        <!-- <label>Confirm Password</label> -->
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      </div>
      <div class="drew">
      <router-link :to="{ name: 'login' }" class="needAccount">
        Have an account?
      </router-link>
      <button class="btn btn-sm btn-primary btn-block" type="submit">
        Create Account
      </button>
      </div>
    </form>
  </div>
</div>
</template>

<script>
export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: 'user',
      },
      registrationErrors: false,
    };
  },
  methods: {
    register() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/register`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.user),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/login', query: { registration: 'success' } });
          } else {
            this.registrationErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
  },
};
</script>

<style scoped>
/* .needAccount{
  color: white;
} */
.register {
  color: white;
  font-weight: bolder;
  background-color: rgba(100, 100, 100, .9);
  text-align: center;
  align-content: center;
  overflow-y:auto;
  max-width: 400px;
}
.form-register{
  
  display: inline-block;
  margin: auto;
}
.drew{
  display: block;
}
.base{
  align-items: center;
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
  background-image: url("../assets/5.jpg");
  background-attachment: fixed;
  overflow-y:auto;
  padding: 50px
}
@media only screen and (min-width: 1079px) {
  .base {
    position: fixed;
  }
}
.btn{
 margin-left: auto;
 margin-right: 20%;
  width: 60%;
  margin-bottom: 10px;
  margin-top: 5px;
}
#username {
  margin-bottom: 10px;
}
#password {
  margin-bottom: 10px;
}
#confirmPassword {
  margin-bottom: 5px;
}
.needAccount {
  margin-bottom: 10px;
}
</style>
