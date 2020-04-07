<template>
  <div>
    <div class="breweryList">
    <h1>Brewery List</h1>
    <div>Welcome {{user.sub}}, {{user.rol}}</div>
  </div>
  </div>
</template>

<script>
import auth from '../auth';
export default {
  name: 'breweryLists',
  data() {
    return{
      user: null
    }
  },
  methods: {

  },
  created() {
    this.user = auth.getUser();
  }
}
</script>

<style>
.breweryList {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding-bottom: 10px;
  text-align: center;
}
</style>