<template>
  <div class="BreweryAdd">
    <h1>Add Brewery</h1>
    <form >
    <div>Name of Brewery: <input type="text" name="Brewery" v-model="Brewery" placeholder="Billy Bob's Shine Factory" /></div>
    <div>Name of Head Brewer: <input placeholder="Billy Bob" /></div>
    <div>User ID: <input placeholder="123" /></div>
    <div>Username: <input placeholder="BillyBob123" /></div>
    <button type="submit" @click.stop.prevent="submit()">Submit</button>
    </form>
  </div>
</template>

<script>
export default {
    data(){
      return {
        Brewery : null
      }
    },
    methods: {
      submit(){
         //if you want to send any data into server before redirection then you can do it here
        this.$router.push("/BreweryList"+this.Brewery);
      }
    }
  }
</script>

<style>
.BreweryAdd {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding-bottom: 10px;
  text-align: center;
}
input{
  width: 20%;
}
</style>