<template>
  <div class="BreweryAdd">
    <h1>Add Brewery</h1>
    <form>
      <div>
        Name of Brewery:
        <input type="text" name="Brewery" v-model="Brewery" placeholder="Billy Bob's Shine Factory" />
      </div>
      <div>
        Name of Head Brewer:
        <input placeholder="Billy Bob" />
      </div>
      <div>
        User ID:
        <input placeholder="123" />
      </div>
      <div>
        Username:
        <input placeholder="BillyBob123" />
      </div>
      <button type="submit" @click.stop.prevent="submit()">Submit</button>
    </form>
  </div>
</template>

<script>
export default {
  name: "breweryAdd",
  data() {
    return {
      user: {
        nameOfBrewery: "",
        HeadBrewer: "",
        UserID: "",
        Username: ""
      },
      registrationErrors: false
    };
  },
  methods: {
    submit() {
      //if you want to send any data into server before redirection then you can do it here

      this.$router.push("/BreweryList");
    },
    register() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/breweryadd`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.brewery)
      })
        .then(response => {
          if (response.ok) {
            this.$router.push({
              path: "/breweryAdd",
              query: { registration: "success" }
            });
          } else {
            this.registrationErrors = true;
          }
        })

        .then(err => console.error(err));
    }
  }
};

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
input {
  width: 20%;
}
</style>