<template>
         <div class="base">
                <div class="home">
                        <h1>Rate this beer.</h1>
                        <form>
                          <div>
                            Name of Beer:
                          </div>
                          <div>
                            Beer Rating (out of 5):
                          </div>
                          <div>
                            Comments:
                          </div>
                        </form>
                </div>
        </div>

</template>

<script>
export default {

}
</script>

<style scoped>
.home {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding-bottom: 10px;
  text-align: center;
}
.base{
  width: auto;
  height: 600px;
  background-image: url('../assets/11.jpg');
}
</style>