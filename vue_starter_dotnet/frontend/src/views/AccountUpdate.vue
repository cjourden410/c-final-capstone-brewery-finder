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
        <div>
          Role:
          <select style="width: 30%" type="text" v-model="user.rol" class="userInput">
            <option value="User">Beer Lover</option>
            <option value="Brewer">Brewer</option>
          </select>
        </div>
        <button v-on:click="saveUser">Edit Selected User</button>
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
      let url = `${process.env.VUE_APP_REMOTE_API}/accountUpdate/${id}`;

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
      let url = `${process.env.VUE_APP_REMOTE_API}/accountUpdate`;

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
      let url = `${process.env.VUE_APP_REMOTE_API}/accountUpdate/${this.selectedUser.id}`;

      fetch(url, {
        method: "PUT",
        headers: { 
          Accept: 'application/json',
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
    this.GetUsers();
  }
};
</script>


<style scoped>
.AccountUpdate {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding: 10px;
  padding-bottom: 20px;
  text-align: center;
}
.base {
  width: auto;
  height: 600px;
  background-image: url("../assets/7.jpg");
}
</style>