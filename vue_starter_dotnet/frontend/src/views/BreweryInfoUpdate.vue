<template>
  <div class="BreweryInfoUpdate">
    <h1>Update Brewery Info</h1>
    <!-- <div>Welcome {{user.sub}}, {{user.rol}}</div> -->
    <form>
      <div>
        Brewery ID:
        <select>
          <option v-for="brewery in brweries" v-value="brewery.id" :key="brewery.id">{{brewery.id}}</option>
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
// import auth from "../auth";

export default {

}
</script>

<style>

</style>