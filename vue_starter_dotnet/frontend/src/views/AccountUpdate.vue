<template>
  <div class="base">
    <div class="AccountUpdate mx-auto">
      <h1>Update Account</h1>
      <form>
        <div class="userName">
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
          <button v-on:click.prevent="saveUser">Edit Selected User</button>
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
          alert("User has been updated!")
          this.chosenId = 0;
          this.selectedUser = null;
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
  color: white;
  font-weight: bolder;
  background-color: rgba(100, 100, 100, .9);
  text-align: center;
  align-content: center;
  overflow-y:auto;
  max-width: 1000px;
}
.base {
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
  background-image: url("../assets/14.jpg");
  background-attachment: fixed;
  overflow-y:auto;
  padding: 50px
}
@media only screen and (min-width: 1079px) {
  .base {
    position: fixed;
  }
}
button{
  border: 1px solid black;
  border-radius: 12px;
  margin: 3px;
  background-color: gainsboro;
  margin-bottom: 10px;
  margin-top: 10px;
}
.userName {
  margin-bottom: 10px;
}
</style>