<template>
  <div id="app">
    <div class="nav">
      <!-- <div>
      <img class="te" :src="require(`../assets/te.png`)" />
      </div>-->
      <meta name="viewport" content="width=device-width, initial-scale=1.0" />
      <meta charset="utf-8" />
      <link
        rel="stylesheet"
        href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"
        integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh"
        crossorigin="anonymous"
      />

      <div class="nav container-fluid">
        <!-- <div>
          <img class="te" src="require(../assets/te.png)" />
        </div> -->
        <div class="log" v-if="user">
          Logged in
          <button v-on:click="logout">Logout</button>
        </div>
        <div class="log" v-else>
          <div>
            <router-link tag="button" :to="{name: 'login'}">Login</router-link>
            <router-link tag="button" :to="{name: 'register'}">Register</router-link>
          </div>
        </div>
        <router-link tag="button" class="navibar" :to="{name: 'home'}">Home</router-link>
        <router-link tag="button" class="navibar" :to="{name: 'breweryList'}">Brewery List</router-link>
        <router-link
          v-if="user && (user.rol === 'Admin')"
          tag="button"
          class="navibar"
          :to="{name: 'breweryAdd'}"
        >Add a new Brewery</router-link>
        <router-link
          v-if="user && (user.rol === 'Admin')"
          tag="button"
          class="navibar"
          :to="{name: 'accountUpdate'}"
        >Update Account</router-link>
        <router-link
          v-if="user && (user.rol === 'Admin' || user.rol === 'Brewer')"
          tag="button"
          class="navibar"
          :to="{name: 'breweryInfoUpdate'}"
        >Update Brewery</router-link>
        <router-link
          v-if="user && (user.rol === 'Admin' || user.rol === 'Brewer')"
          tag="button"
          class="navibar"
          :to="{name: 'beerAdd'}"
        >Add a Beer</router-link>
        <router-link
          v-if="user && (user.rol === 'Admin' || user.rol === 'Brewer' || user.rol === 'User')"
          tag="button"
          class="navibar"
          :to="{name: 'viewRatings'}"
        >View Ratings</router-link>
        <!-- <router-link v-if="user && (user.rol === 'Admin' || user.rol === 'Brewer')" tag="button" class="navibar" :to="{name: 'deleteBeer'}">Delete Beer</router-link> -->
      </div>
    </div>
    <router-view class="routerView container-fluid" v-bind:user="this.user" />
  </div>
</template>

<script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>

<script>
import auth from "@/auth.js";

export default {
  data() {
    return {
      user: null
    };
  },
  methods: {
    logout() {
      auth.logout();
      this.$router.push("/login");
      this.user = null;
    }
  },
  created() {
    this.user = auth.getUser();
  },
  watch: {
    $route: function() {
      this.user = auth.getUser();
    }
  }
};
</script>

<style scoped>
.navibar {
  font-weight: bolder;
  display: inline-block;
  background-color: gainsboro;
  padding-left: 5px;
  margin: 3px;
  height: 30px;
}
button {
  font-weight: bolder;
  border: 1px solid black;
  border-radius: 12px;
}
.nav {
  background-color: goldenrod;
}
.log {
  margin-top: 4px;
}
</style>