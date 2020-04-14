<template>
  <div class="base">
    <div class="AccountUpdate">
      <h1>Update Account</h1>
      <form>
        <div>
          Username:
          <select style="width: 30%" @change="getUser(chosenId)" v-model="chosenId">
            <option v-for="user in users" :key="user.id" v-bind:value="user.id">{{user.username}}</option>
          </select>
        </div>
        <div v-if="selectedUser">
          <div>
          Role:
          <select style="width: 30%" type="text" v-model="selectedUser.role" class="userInput">
            <option value="User">Beer Lover</option>
            <option value="Brewer">Brewer</option>
          </select>
          </div>
          <button v-on:click="saveUser">Edit Selected User</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
// import auth from "../auth";
// import UserList from "@/components/UsersList.vue";

export default {
  name: "accountUpdate",
  props: {},
  data() {
    return {
      selectedUser: null,
      users: [],
      chosenId: Number,
      user: Object
    };
  },
  methods: {
    getUser(id) {
      let url = `${process.env.VUE_APP_REMOTE_API}/${id}`;

      fetch(url)
        .then(response => {
          response.json().then(json => {
            this.selectedUser = json;
          });
        })
        .catch(err => {
          console.log(err);
        });
    },
    getUsers() {
      let url = `${process.env.VUE_APP_REMOTE_API}/`;

      fetch(url)
        .then(response => {
          response.json().then(json => {
            this.users = json;
          });
        })
        .catch(err => {
          console.log(err);
        });
    },
    saveUser() {
      let url = `${process.env.VUE_APP_REMOTE_API}/${this.selectedUser.id}`;

      fetch(url, {
        method: "PUT",
        headers: { 
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.selectedUser)
      }).then(response => {
        if (response.ok) {
          alert("User has been updated!");
        } else {
          alert(
            `There was an error updating: ${response.status}: ${response.statusText}`
          );
        }
      });
    }
  },
  created() {
    this.user = this.$attrs.user;
    this.getUsers();
  }
};
</script>


<style scoped>
.AccountUpdate {
  background-color: whitesmoke;
  border-radius: 35%;
  width: 40%;
  margin-left: 30%;
  margin-right: 15%;
  padding: 20px;
  padding-bottom: 50px;
  text-align: center;
  overflow-y:auto;
}
.base {
  width: 100vw;
  height: 100vh;
  background-size: cover;
  overflow: hidden;
  position: fixed; 
  top: 1; 
  left: 0;
  background-attachment: fixed;
  min-width: 100%;
  min-height: 100%;;
  background-image: url("../assets/7.jpg");
  overflow-y:auto;
}
</style>