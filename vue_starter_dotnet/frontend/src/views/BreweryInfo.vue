<template>
  <div class="brewery">
    <h1>{{brewery.name}}</h1>
    <h2>Details</h2>
    <table class="form">
      <tr>
        <td>Name</td>
        <td>{{brewery.name}}</td>
      </tr>
            <tr>
        <td>Address</td>
        <td>{{brewery.address}}</td>
      </tr>
            <tr>
        <td>Contact Info</td>
        <td>{{brewery.contact}}</td>
      </tr>
            <tr>
        <td>Hours of Opperation</td>
        <td>{{brewery.daysHours}}</td>
      </tr>
    </table>
  </div>
</template>

<script>
import auth from "@/auth.js";

export default {
  name: "brewery",
  props: {
    id: Number
  },
  data(){
    return{
      brewery: {
        id: 0,
        name: "",
        contact: "",
        daysHours: "",
        picture: "",
        address: ""
      }
    }
  },
 methods: {
    getBrewery(id) {
      // This is the url...
      let url = `${process.env.VUE_APP_REMOTE_API}/brewery/${id}`;

      // fetch here...
      fetch(url)
        .then(responce => {
          responce.json()
            .then(json => {
              this.brewery = json;
            })
        }).catch(err => {console.log(err)});
    }
  },
  created() {
      this.getBrewery(this.$route.params.id);
  }
}
</script>

<style>

</style>