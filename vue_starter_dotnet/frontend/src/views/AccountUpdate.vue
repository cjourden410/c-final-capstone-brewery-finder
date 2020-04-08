<template>
  <div class="AccountUpdate">
    <h1>Update Account</h1>
    <form>
      <div>
        UserID:
        <select>
          <option v-for="user in users" type="number" v-value="user.id" :key="user.id">{{user.id}}</option>
        </select>
      </div>
      <div>
        Role:
        <select style="width: 30%" type="text" v-model="user.role" class="userInput">
          <users-list :users="users" class="userlist"></users-list>
          <option value="User">Beer Lover</option>
          <option value="Brewer">Brewer</option>
        </select>
      </div>
      <button v-on:click="register">Submit</button>
    </form>
  </div>
</template>

<script>
import auth from "../auth";
import UserList from "@/components/UsersList.vue";

export default {
  name: "users",
  components: {
    "users-list": UserList
  },
  data() {
    return {
      user: null
    };
  },
  methods: {
    GetUsers() {
      let url = `${process.env.VUE_APP_REMOTE_API}/userList`;

      fetch(url)
        .then(response => {
          response.json().then(json => {
            this.Users = json;
          });
        })
        .catch(err => {
          console.log(err);
        });
    }
  },
  created() {
    this.user = auth.getUser();
    this.GetUsers();
  }
};
</script>


<style>
.AccountUpdate {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding-bottom: 10px;
  text-align: center;
  margin: auto;
}
</style>